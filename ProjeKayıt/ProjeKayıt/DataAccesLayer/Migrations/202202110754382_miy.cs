namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class miy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contents", "CategoryID", c => c.Int());
            CreateIndex("dbo.Contents", "CategoryID");
            AddForeignKey("dbo.Contents", "CategoryID", "dbo.Categories", "CategoryID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contents", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Contents", new[] { "CategoryID" });
            DropColumn("dbo.Contents", "CategoryID");
        }
    }
}
