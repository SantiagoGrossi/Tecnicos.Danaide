namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionesAreas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RelacionesAreas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AreasTecnicosId = c.Int(nullable: false),
                        TecnicoId = c.String(maxLength: 128),
                        AreaTecnicos_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AreaTecnicos", t => t.AreaTecnicos_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.TecnicoId)
                .Index(t => t.TecnicoId)
                .Index(t => t.AreaTecnicos_Id);
            
            CreateTable(
                "dbo.RelacionesClientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientesId = c.Int(nullable: false),
                        TecnicoId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClientesId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.TecnicoId)
                .Index(t => t.ClientesId)
                .Index(t => t.TecnicoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RelacionesClientes", "TecnicoId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RelacionesClientes", "ClientesId", "dbo.Clientes");
            DropForeignKey("dbo.RelacionesAreas", "TecnicoId", "dbo.AspNetUsers");
            DropForeignKey("dbo.RelacionesAreas", "AreaTecnicos_Id", "dbo.AreaTecnicos");
            DropIndex("dbo.RelacionesClientes", new[] { "TecnicoId" });
            DropIndex("dbo.RelacionesClientes", new[] { "ClientesId" });
            DropIndex("dbo.RelacionesAreas", new[] { "AreaTecnicos_Id" });
            DropIndex("dbo.RelacionesAreas", new[] { "TecnicoId" });
            DropTable("dbo.RelacionesClientes");
            DropTable("dbo.RelacionesAreas");
        }
    }
}
