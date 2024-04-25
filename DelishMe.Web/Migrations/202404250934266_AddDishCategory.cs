namespace DelishMe.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDishCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(),
                        CategoryId = c.Byte(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dishes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Dishes", new[] { "CategoryId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Dishes");
        }
    }
}
