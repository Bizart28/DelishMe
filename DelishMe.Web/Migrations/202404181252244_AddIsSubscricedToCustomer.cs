namespace DelishMe.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscricedToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubcribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubcribedToNewsLetter");
        }
    }
}
