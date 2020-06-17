namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacionesAreasYClientes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "EsTecnico", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "EsPm", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "EsPm");
            DropColumn("dbo.AspNetUsers", "EsTecnico");
        }
    }
}
