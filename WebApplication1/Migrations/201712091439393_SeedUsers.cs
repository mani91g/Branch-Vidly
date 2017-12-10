namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b14e0e83-0257-433f-8b3e-5d4d378aa7c6', N'guest@vidly.com', 0, N'ADkV7jy2NsUbqif6mOqwY1aFWE/+usSogSzxWlINoyNpsua10Pqj0mN2WMz4SRqJPA==', N'79aed4e2-5aab-4b0e-b50f-068e056ec59b', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ce9252bf-e186-4e2a-8bcc-e1265d9be919', N'admin@vidly.com', 0, N'AP2e7j0yjfK4SposvxD57q3bUsbz3e7qqW5caLJLXIYAhuMcIaUjvO4+Wi/UqxF0Tg==', N'869eec61-66bf-45f4-89c1-b41ead3e3950', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1bf00b10-a4d0-4ffe-8833-7f939c249cc9', N'CanManageMovie')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ce9252bf-e186-4e2a-8bcc-e1265d9be919', N'1bf00b10-a4d0-4ffe-8833-7f939c249cc9')
                ");
        }

        public override void Down()
        {
        }
    }
}
