namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuarioEnTarea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TareasDiarias", "UsuarioId", c => c.Int(nullable: false));
            AddColumn("dbo.TareasDiarias", "Usuario_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.TareasDiarias", "Usuario_Id");
            AddForeignKey("dbo.TareasDiarias", "Usuario_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TareasDiarias", "Usuario_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TareasDiarias", new[] { "Usuario_Id" });
            DropColumn("dbo.TareasDiarias", "Usuario_Id");
            DropColumn("dbo.TareasDiarias", "UsuarioId");
        }
    }
}
