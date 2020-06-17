namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IssueModelInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Descripcion = c.String(),
                        DerivadaDeUserId = c.String(),
                        TecnicoAsignadoUserId = c.String(),
                        AreaTecnicosId = c.Int(nullable: false),
                        FechaCreada = c.DateTime(),
                        FechaCerrada = c.DateTime(),
                        FechaCreadaString = c.String(),
                        FechaCerradaString = c.String(),
                        EstadoIssueId = c.Int(nullable: false),
                        CreadaPorUserId = c.String(),
                        ClienteId = c.Int(nullable: false),
                        CriticidadIssueId = c.Int(nullable: false),
                        VecesReclamado = c.Int(),
                        Clientes_Id = c.Int(),
                        CreadaPor_Id = c.String(maxLength: 128),
                        DerivadaDe_Id = c.String(maxLength: 128),
                        TecnicoAsignado_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AreaTecnicos", t => t.AreaTecnicosId, cascadeDelete: true)
                .ForeignKey("dbo.Clientes", t => t.Clientes_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreadaPor_Id)
                .ForeignKey("dbo.CriticidadIssues", t => t.CriticidadIssueId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.DerivadaDe_Id)
                .ForeignKey("dbo.EstadoIssues", t => t.EstadoIssueId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.TecnicoAsignado_Id)
                .Index(t => t.AreaTecnicosId)
                .Index(t => t.EstadoIssueId)
                .Index(t => t.CriticidadIssueId)
                .Index(t => t.Clientes_Id)
                .Index(t => t.CreadaPor_Id)
                .Index(t => t.DerivadaDe_Id)
                .Index(t => t.TecnicoAsignado_Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        CantidadTecnicosAsignados = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "TecnicoAsignado_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Issues", "EstadoIssueId", "dbo.EstadoIssues");
            DropForeignKey("dbo.Issues", "DerivadaDe_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Issues", "CriticidadIssueId", "dbo.CriticidadIssues");
            DropForeignKey("dbo.Issues", "CreadaPor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Issues", "Clientes_Id", "dbo.Clientes");
            DropForeignKey("dbo.Issues", "AreaTecnicosId", "dbo.AreaTecnicos");
            DropIndex("dbo.Issues", new[] { "TecnicoAsignado_Id" });
            DropIndex("dbo.Issues", new[] { "DerivadaDe_Id" });
            DropIndex("dbo.Issues", new[] { "CreadaPor_Id" });
            DropIndex("dbo.Issues", new[] { "Clientes_Id" });
            DropIndex("dbo.Issues", new[] { "CriticidadIssueId" });
            DropIndex("dbo.Issues", new[] { "EstadoIssueId" });
            DropIndex("dbo.Issues", new[] { "AreaTecnicosId" });
            DropTable("dbo.Clientes");
            DropTable("dbo.Issues");
        }
    }
}
