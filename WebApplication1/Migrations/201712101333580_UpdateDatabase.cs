namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MobileNumber", c => c.String(nullable: false, maxLength: 50));
            
        }
        
        public override void Down()
        {            
            DropColumn("dbo.AspNetUsers", "MobileNumber");
        }
    }
}
