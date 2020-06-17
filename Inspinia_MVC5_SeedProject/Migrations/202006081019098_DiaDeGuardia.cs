namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiaDeGuardia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiaDeGuardias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioDeGuardiaId = c.String(maxLength: 128),
                        Inicia = c.DateTime(nullable: false),
                        Termina = c.DateTime(nullable: false),
                        IniciaString = c.String(),
                        TerminaString = c.String(),
                        EsDiaNoHabil = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioDeGuardiaId)
                .Index(t => t.UsuarioDeGuardiaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiaDeGuardias", "UsuarioDeGuardiaId", "dbo.AspNetUsers");
            DropIndex("dbo.DiaDeGuardias", new[] { "UsuarioDeGuardiaId" });
            DropTable("dbo.DiaDeGuardias");
        }
    }
}
