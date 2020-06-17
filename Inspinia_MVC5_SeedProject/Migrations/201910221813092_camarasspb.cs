namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class camarasspb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CamarasSPBs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estado = c.Boolean(nullable: false),
                        Nombre = c.String(),
                        UnidadId = c.Int(nullable: false),
                        UnidadesSPB_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UnidadesSPBs", t => t.UnidadesSPB_Id)
                .Index(t => t.UnidadesSPB_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CamarasSPBs", "UnidadesSPB_Id", "dbo.UnidadesSPBs");
            DropIndex("dbo.CamarasSPBs", new[] { "UnidadesSPB_Id" });
            DropTable("dbo.CamarasSPBs");
        }
    }
}
