namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatosDeTareasEnCantidadEnTablaUsuarios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CantTareasTotal", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "CantTareasPendientes", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "CantTareasHoy", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CantTareasHoy");
            DropColumn("dbo.AspNetUsers", "CantTareasPendientes");
            DropColumn("dbo.AspNetUsers", "CantTareasTotal");
        }
    }
}
