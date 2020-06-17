namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModelTecnicos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "CantTareasTotal", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "CantTareasPendientes", c => c.Int());
            AlterColumn("dbo.AspNetUsers", "CantTareasHoy", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "CantTareasHoy", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "CantTareasPendientes", c => c.Int(nullable: false));
            AlterColumn("dbo.AspNetUsers", "CantTareasTotal", c => c.Int(nullable: false));
        }
    }
}
