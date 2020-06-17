namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnidadesSPB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UnidadesSPBs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Estado = c.Boolean(nullable: false),
                        HoraCaida = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UnidadesSPBs");
        }
    }
}
