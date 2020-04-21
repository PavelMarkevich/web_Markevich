namespace web_server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Description", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Books", "ImageSrc", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Name", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Name", c => c.String());
            DropColumn("dbo.Books", "ImageSrc");
            DropColumn("dbo.Books", "Description");
        }
    }
}
