namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useridesstringentareasdiarias : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.TareasDiarias", new[] { "Usuario_Id" });
            DropColumn("dbo.TareasDiarias", "UsuarioId");
            RenameColumn(table: "dbo.TareasDiarias", name: "Usuario_Id", newName: "UsuarioId");
            AlterColumn("dbo.TareasDiarias", "UsuarioId", c => c.String(maxLength: 128));
            CreateIndex("dbo.TareasDiarias", "UsuarioId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TareasDiarias", new[] { "UsuarioId" });
            AlterColumn("dbo.TareasDiarias", "UsuarioId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.TareasDiarias", name: "UsuarioId", newName: "Usuario_Id");
            AddColumn("dbo.TareasDiarias", "UsuarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.TareasDiarias", "Usuario_Id");
        }
    }
}
