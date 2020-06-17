namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnidadesN : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UnidadesSPBs", "NumeroUnidad", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UnidadesSPBs", "NumeroUnidad");
        }
    }
}
