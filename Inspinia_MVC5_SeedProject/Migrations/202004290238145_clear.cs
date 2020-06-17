namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clear : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CamarasSPBs", "UnidadesSPB_Id", "dbo.UnidadesSPBs");
            DropForeignKey("dbo.Guardias", "TipoGuardiaId", "dbo.TipoGuardias");
            DropForeignKey("dbo.Guardias", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.HorasExtras", "tipoHoraExtraId", "dbo.TipoHoraExtras");
            DropForeignKey("dbo.HorasExtras", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TareasDiarias", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TareasGuardias", "UsuarioId", "dbo.AspNetUsers");
            DropIndex("dbo.CamarasSPBs", new[] { "UnidadesSPB_Id" });
            DropIndex("dbo.Guardias", new[] { "TipoGuardiaId" });
            DropIndex("dbo.Guardias", new[] { "UsuarioId" });
            DropIndex("dbo.HorasExtras", new[] { "UsuarioId" });
            DropIndex("dbo.HorasExtras", new[] { "tipoHoraExtraId" });
            DropIndex("dbo.TareasDiarias", new[] { "UsuarioId" });
            DropIndex("dbo.TareasGuardias", new[] { "UsuarioId" });
            DropTable("dbo.CamarasMalvinas");
            DropTable("dbo.CamarasSPBs");
            DropTable("dbo.UnidadesSPBs");
            DropTable("dbo.Clientes");
            DropTable("dbo.EstadosTickets");
            DropTable("dbo.Guardias");
            DropTable("dbo.TipoGuardias");
            DropTable("dbo.HorasExtras");
            DropTable("dbo.TipoHoraExtras");
            DropTable("dbo.LogLats");
            DropTable("dbo.TareasDiarias");
            DropTable("dbo.TareasGuardias");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TareasGuardias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Resumen = c.String(),
                        Descripcion = c.String(),
                        Minutos = c.Int(),
                        FechaCreada = c.DateTime(nullable: false),
                        NombreCliente = c.String(),
                        Finalizada = c.Boolean(nullable: false),
                        Numero = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                        UsuarioNombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TareasDiarias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Resumen = c.String(),
                        Descripcion = c.String(),
                        Minutos = c.Int(),
                        FechaCreada = c.DateTime(nullable: false),
                        NombreCliente = c.String(),
                        Finalizada = c.Boolean(nullable: false),
                        Numero = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                        UsuarioNombre = c.String(),
                        FueAsignada = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            CreateTable(
                "dbo.TipoHoraExtras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                        Valor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HorasExtras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.String(maxLength: 128),
                        Cantidad = c.Int(nullable: false),
                        NumeroMes = c.Int(nullable: false),
                        NombreMes = c.String(),
                        tipoHoraExtraId = c.Int(),
                        TipoHoraExtraNombre = c.String(),
                        Motivo = c.String(),
                        UsuarioNombre = c.String(),
                        Fecha = c.DateTime(),
                        Desde = c.String(),
                        Hasta = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoGuardias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Guardias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInicio = c.DateTime(nullable: false),
                        FechaFin = c.DateTime(nullable: false),
                        TipoGuardiaId = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EstadosTickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estado = c.String(),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnidadesSPBs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Estado = c.Boolean(nullable: false),
                        HoraCaído = c.DateTime(),
                        Ubicación = c.String(),
                        NumeroUnidad = c.Int(nullable: false),
                        PorcentajeCaido = c.Int(),
                        CamarasConVideo = c.Int(),
                        CamarasSinVideo = c.Int(),
                        CamarasTotales = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CamarasSPBs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estado = c.Boolean(nullable: false),
                        Nombre = c.String(),
                        UnidadId = c.Int(nullable: false),
                        NumeroUnidad = c.Int(nullable: false),
                        UnidadesSPB_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CamarasMalvinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCamara = c.String(),
                        Ip = c.String(),
                        TieneVideo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.TareasGuardias", "UsuarioId");
            CreateIndex("dbo.TareasDiarias", "UsuarioId");
            CreateIndex("dbo.HorasExtras", "tipoHoraExtraId");
            CreateIndex("dbo.HorasExtras", "UsuarioId");
            CreateIndex("dbo.Guardias", "UsuarioId");
            CreateIndex("dbo.Guardias", "TipoGuardiaId");
            CreateIndex("dbo.CamarasSPBs", "UnidadesSPB_Id");
            AddForeignKey("dbo.TareasGuardias", "UsuarioId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.TareasDiarias", "UsuarioId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.HorasExtras", "UsuarioId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.HorasExtras", "tipoHoraExtraId", "dbo.TipoHoraExtras", "Id");
            AddForeignKey("dbo.Guardias", "UsuarioId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Guardias", "TipoGuardiaId", "dbo.TipoGuardias", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CamarasSPBs", "UnidadesSPB_Id", "dbo.UnidadesSPBs", "Id");
        }
    }
}
