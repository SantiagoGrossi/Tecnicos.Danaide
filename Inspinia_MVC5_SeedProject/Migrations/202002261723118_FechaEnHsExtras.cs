namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FechaEnHsExtras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HorasExtras", "Fecha", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HorasExtras", "Fecha");
        }
    }
}
