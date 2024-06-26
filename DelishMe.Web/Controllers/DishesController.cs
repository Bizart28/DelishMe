﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DelishMe.Web.Models;
using DelishMe.Web.ViewModels;
using DelishMe.Web.Migrations;
using System.Data.Entity;
using System.IO;


namespace DelishMe.Web.Controllers
{
    public class DishesController : Controller
    {
        private ApplicationDbContext _context;

        public DishesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            if (User.IsInRole("CanManageDishes")) return View("List");
            else return View("ReadOnlyList");

        }

        public ActionResult Details(int id)
        {
           
            var dish = _context.Dishes.Include(m => m.Category).SingleOrDefault(m => m.Id == id);

            if (dish == null)
                return HttpNotFound();

            return View(dish);

        }


        // GET: Dishes
        
      

        [Authorize(Roles = RoleName.CanManageDishes)]
        public ViewResult New()
        {
            var categories = _context.Categories.ToList();

            var viewModel = new DishFormViewModel
            {
                Categories = categories
            };

            return View("DishForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageDishes)]
        public ActionResult Edit(int id)
        {
            var dish = _context.Dishes.SingleOrDefault(c => c.Id == id);

            if (dish == null)
                return HttpNotFound();

            var viewModel = new DishFormViewModel(dish)
            {
                Categories = _context.Categories.ToList(),
            };
          

            return View("DishForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageDishes)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Dish dish, HttpPostedFileBase ImageUpload)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DishFormViewModel(dish)
                {
                    Categories = _context.Categories.ToList()
                };

                return View("DishForm", viewModel);
            }

            // Проверка получения файла
            if (ImageUpload != null)
            {
                Console.WriteLine($"Received file: {ImageUpload.FileName}");
                if (ImageUpload.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(ImageUpload.FileName);
                    var path = Path.Combine(Server.MapPath("~/images/"), fileName);  // Изменено на "images"

                    Console.WriteLine($"Saving file to: {path}");

                    try
                    {
                        ImageUpload.SaveAs(path);
                        dish.ImagePath = "/images/" + fileName;
                        Console.WriteLine($"File saved successfully: {dish.ImagePath}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error saving file: {ex.Message}");
                        ModelState.AddModelError("ImageUpload", "Error saving file");
                        var viewModel = new DishFormViewModel(dish)
                        {
                            Categories = _context.Categories.ToList()
                        };
                        return View("DishForm", viewModel);
                    }
                }
            }

            if (dish.Id == 0)
            {
                dish.DateAdded = DateTime.Now;
                _context.Dishes.Add(dish);
            }
            else
            {
                var dishInDb = _context.Dishes.SingleOrDefault(m => m.Id == dish.Id);
                if (dishInDb == null)
                    return HttpNotFound();

                dishInDb.Name = dish.Name;
                dishInDb.CategoryId = dish.CategoryId;
                dishInDb.Description = dish.Description;

                // Обновление пути к изображению только если файл был загружен
                if (!string.IsNullOrEmpty(dish.ImagePath))
                {
                    dishInDb.ImagePath = dish.ImagePath;
                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Dishes");
        }


    }
}