namespace DelishMe.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'78928c26-e0ac-44ef-8703-e303ebf29481', N'guest@delishMe.com', 0, N'AEfv9zNeIQhpoiY1zDCQIgv+JLRB0qVGUm1w71rbjo8HIvNF7pJpzg5rJc0bEZAXzQ==', N'ecb0fdc2-2226-4c2d-9ab5-fccba613196d', NULL, 0, 0, NULL, 1, 0, N'guest@delishMe.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f8d3e919-152f-4237-8e5e-706e78192b90', N'admin@delishMe.com', 0, N'AAE3TplduGeYogQ+x6bPUV7sdtSAUNDlyoyCcNKiAxj4Rh2d2K9LBcVZvNKnZGpXwQ==', N'3d5dc98d-ff94-42b8-876a-999549580e1c', NULL, 0, 0, NULL, 1, 0, N'admin@delishMe.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'321a269b-f9e4-42e7-9e78-14644e6226ec', N'CanManageDishes')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f8d3e919-152f-4237-8e5e-706e78192b90', N'321a269b-f9e4-42e7-9e78-14644e6226ec')

");
        }
        
        public override void Down()
        {
        }
    }
}
