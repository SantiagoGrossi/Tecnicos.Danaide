namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SPBCambioFecha : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UnidadesSPBs", "HoraCaida");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UnidadesSPBs", "HoraCaida", c => c.DateTime(nullable: false));
        }
    }
}
