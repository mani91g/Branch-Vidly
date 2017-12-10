namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenre_Drama : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into Genres VALUES ('DRAMA')");
        }
        
        public override void Down()
        {
        }
    }
}
