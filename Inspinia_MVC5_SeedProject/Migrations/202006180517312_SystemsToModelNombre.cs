namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SystemsToModelNombre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Systems", "Nombre", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Systems", "Nombre");
        }
    }
}
