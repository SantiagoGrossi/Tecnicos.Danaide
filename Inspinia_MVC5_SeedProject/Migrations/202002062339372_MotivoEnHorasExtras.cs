namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MotivoEnHorasExtras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HorasExtras", "Motivo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HorasExtras", "Motivo");
        }
    }
}
