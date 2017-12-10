namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterMovieTable_ColumnName_ImdbName_ImdbRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ImdbRating", c => c.Single(nullable: false));
            DropColumn("dbo.Movies", "ImdbName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "ImdbName", c => c.Single(nullable: false));
            DropColumn("dbo.Movies", "ImdbRating");
        }
    }
}
