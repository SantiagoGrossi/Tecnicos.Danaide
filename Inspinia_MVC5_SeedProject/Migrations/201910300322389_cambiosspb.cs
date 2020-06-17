namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiosspb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UnidadesSPBs", "CamarasConVideo", c => c.Int());
            AddColumn("dbo.UnidadesSPBs", "CamarasSinVideo", c => c.Int());
            AddColumn("dbo.UnidadesSPBs", "CamarasTotales", c => c.Int());
            AlterColumn("dbo.UnidadesSPBs", "PorcentajeCaido", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UnidadesSPBs", "PorcentajeCaido", c => c.Int(nullable: false));
            DropColumn("dbo.UnidadesSPBs", "CamarasTotales");
            DropColumn("dbo.UnidadesSPBs", "CamarasSinVideo");
            DropColumn("dbo.UnidadesSPBs", "CamarasConVideo");
        }
    }
}
