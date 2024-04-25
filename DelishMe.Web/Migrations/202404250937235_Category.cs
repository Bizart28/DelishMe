namespace DelishMe.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Category : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'Salad')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'Soup')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (3, 'Dessert')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (4, 'Meat')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (5, 'Drink')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (6, 'Bakery')");
        }
        
        public override void Down()
        {
        }
    }
}
