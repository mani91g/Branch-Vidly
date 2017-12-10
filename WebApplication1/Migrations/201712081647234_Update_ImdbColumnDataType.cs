namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_ImdbColumnDataType : DbMigration
    {
        public override void Up()
        {
            //Sql("ALTER TABLE Movies DROP CONSTRAINT DF__Movies__ImdbRati__47DBAE45");
            AlterColumn("dbo.Movies", "ImdbRating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "ImdbRating", c => c.Single(nullable: false));
        }
    }
}
