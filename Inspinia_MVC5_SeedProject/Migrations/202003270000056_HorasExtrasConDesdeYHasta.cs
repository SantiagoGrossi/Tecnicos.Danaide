namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HorasExtrasConDesdeYHasta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HorasExtras", "Desde", c => c.String());
            AddColumn("dbo.HorasExtras", "Hasta", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HorasExtras", "Hasta");
            DropColumn("dbo.HorasExtras", "Desde");
        }
    }
}
