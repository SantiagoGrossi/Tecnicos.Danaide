namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AsignadaEnTareas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TareasDiarias", "FueAsignada", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TareasDiarias", "FueAsignada");
        }
    }
}
