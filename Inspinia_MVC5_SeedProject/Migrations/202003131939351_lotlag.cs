namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lotlag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogLats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Direct = c.String(),
                        Lat = c.String(),
                        Log = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogLats");
        }
    }
}
