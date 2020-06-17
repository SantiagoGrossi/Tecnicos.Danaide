namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tareasGuardias : DbMigration
    {
        public override void Up()
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
                        ClienteId = c.Int(nullable: false),
                        Finalizada = c.Boolean(nullable: false),
                        Numero = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                        UsuarioNombre = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.ClienteId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TareasGuardias", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TareasGuardias", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.TareasGuardias", new[] { "UsuarioId" });
            DropIndex("dbo.TareasGuardias", new[] { "ClienteId" });
            DropTable("dbo.TareasGuardias");
        }
    }
}
