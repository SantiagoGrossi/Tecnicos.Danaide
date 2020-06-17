namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NombreEnHsExtraTabla : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HorasExtras", "UsuarioNombre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HorasExtras", "UsuarioNombre");
        }
    }
}
