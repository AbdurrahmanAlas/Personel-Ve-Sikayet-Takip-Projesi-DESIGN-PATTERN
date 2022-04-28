namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "Telefon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headings", "Telefon");
        }
    }
}
