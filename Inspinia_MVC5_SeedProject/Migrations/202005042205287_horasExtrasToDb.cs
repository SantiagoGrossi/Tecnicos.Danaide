namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class horasExtrasToDb : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoHoraExtras", t => t.tipoHoraExtraId)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.tipoHoraExtraId);
            
            CreateTable(
                "dbo.TipoHoraExtras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                        Valor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HorasExtras", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.HorasExtras", "tipoHoraExtraId", "dbo.TipoHoraExtras");
            DropIndex("dbo.HorasExtras", new[] { "tipoHoraExtraId" });
            DropIndex("dbo.HorasExtras", new[] { "UsuarioId" });
            DropTable("dbo.TipoHoraExtras");
            DropTable("dbo.HorasExtras");
        }
    }
}
