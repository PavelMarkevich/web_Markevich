namespace web_server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Author", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Books", "Name", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "Name", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Books", "Author");
        }
    }
}
