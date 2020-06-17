namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tareasComunitarias : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AporteComunitarias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        TiempoDedicado = c.String(),
                        AportanteId = c.String(maxLength: 128),
                        FechaAporte = c.DateTime(),
                        FechaAporteString = c.String(),
                        PendientesMesaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AportanteId)
                .ForeignKey("dbo.PendientesMesas", t => t.PendientesMesaId, cascadeDelete: true)
                .Index(t => t.AportanteId)
                .Index(t => t.PendientesMesaId);
            
            CreateTable(
                "dbo.PendientesMesas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Descripcion = c.String(),
                        FechaCreada = c.DateTime(),
                        FechaCerrada = c.DateTime(),
                        FechaCreadaString = c.String(),
                        FechaCerradaString = c.String(),
                        EstadoIssueId = c.Int(nullable: false),
                        CreadaPorId = c.String(maxLength: 128),
                        TiempoDedicado = c.String(),
                        CerradaPorId = c.String(maxLength: 128),
                        NumeroPendiente = c.Int(),
                        ClientesId = c.Int(nullable: false),
                        TiempoResultante = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CerradaPorId)
                .ForeignKey("dbo.Clientes", t => t.ClientesId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreadaPorId)
                .ForeignKey("dbo.EstadoIssues", t => t.EstadoIssueId, cascadeDelete: true)
                .Index(t => t.EstadoIssueId)
                .Index(t => t.CreadaPorId)
                .Index(t => t.CerradaPorId)
                .Index(t => t.ClientesId);
            
            CreateTable(
                "dbo.MensajesPendientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaCreado = c.DateTime(nullable: false),
                        PendientesMesaId = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                        Mensaje = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PendientesMesas", t => t.PendientesMesaId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.PendientesMesaId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MensajesPendientes", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MensajesPendientes", "PendientesMesaId", "dbo.PendientesMesas");
            DropForeignKey("dbo.AporteComunitarias", "PendientesMesaId", "dbo.PendientesMesas");
            DropForeignKey("dbo.PendientesMesas", "EstadoIssueId", "dbo.EstadoIssues");
            DropForeignKey("dbo.PendientesMesas", "CreadaPorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PendientesMesas", "ClientesId", "dbo.Clientes");
            DropForeignKey("dbo.PendientesMesas", "CerradaPorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AporteComunitarias", "AportanteId", "dbo.AspNetUsers");
            DropIndex("dbo.MensajesPendientes", new[] { "UsuarioId" });
            DropIndex("dbo.MensajesPendientes", new[] { "PendientesMesaId" });
            DropIndex("dbo.PendientesMesas", new[] { "ClientesId" });
            DropIndex("dbo.PendientesMesas", new[] { "CerradaPorId" });
            DropIndex("dbo.PendientesMesas", new[] { "CreadaPorId" });
            DropIndex("dbo.PendientesMesas", new[] { "EstadoIssueId" });
            DropIndex("dbo.AporteComunitarias", new[] { "PendientesMesaId" });
            DropIndex("dbo.AporteComunitarias", new[] { "AportanteId" });
            DropTable("dbo.MensajesPendientes");
            DropTable("dbo.PendientesMesas");
            DropTable("dbo.AporteComunitarias");
        }
    }
}
