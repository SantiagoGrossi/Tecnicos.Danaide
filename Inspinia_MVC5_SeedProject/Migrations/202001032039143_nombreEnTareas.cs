namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nombreEnTareas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TareasDiarias", "UsuarioNombre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TareasDiarias", "UsuarioNombre");
        }
    }
}
