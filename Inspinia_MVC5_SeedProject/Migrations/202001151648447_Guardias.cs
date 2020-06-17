namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Guardias : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TipoGuardias", t => t.TipoGuardiaId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.TipoGuardiaId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Guardias", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Guardias", "TipoGuardiaId", "dbo.TipoGuardias");
            DropIndex("dbo.Guardias", new[] { "UsuarioId" });
            DropIndex("dbo.Guardias", new[] { "TipoGuardiaId" });
            DropTable("dbo.Guardias");
        }
    }
}
