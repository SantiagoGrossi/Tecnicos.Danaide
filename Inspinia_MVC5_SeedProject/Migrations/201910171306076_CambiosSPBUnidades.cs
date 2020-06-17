namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiosSPBUnidades : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UnidadesSPBs", "HoraCaído", c => c.DateTime());
            AddColumn("dbo.UnidadesSPBs", "Ubicación", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UnidadesSPBs", "Ubicación");
            DropColumn("dbo.UnidadesSPBs", "HoraCaído");
        }
    }
}
