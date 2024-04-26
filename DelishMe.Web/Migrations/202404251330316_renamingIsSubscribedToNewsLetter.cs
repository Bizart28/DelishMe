namespace DelishMe.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamingIsSubscribedToNewsLetter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "IsSubcribedToNewsLetter");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "IsSubcribedToNewsLetter", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "IsSubscribedToNewsLetter");
        }
    }
}
