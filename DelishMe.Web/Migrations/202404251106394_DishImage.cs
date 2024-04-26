namespace DelishMe.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DishImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dishes", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dishes", "ImagePath");
        }
    }
}
