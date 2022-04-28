namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class punıshme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Punishments",
                c => new
                    {
                        CezaId = c.Int(nullable: false, identity: true),
                        DocumentTipi = c.String(),
                        CompanyName = c.String(),
                        CezaTeam = c.String(),
                        Description = c.String(),
                        DocumentName = c.String(),
                        CezaPhoto = c.String(),
                        CezaAmont = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Boolean(nullable: false),
                        CezaDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CezaId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Punishments");
        }
    }
}
