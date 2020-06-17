namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoHoraExtraEnHorasExtras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HorasExtras", "tipoHoraExtraId", c => c.Int());
            AddColumn("dbo.HorasExtras", "TipoHoraExtraNombre", c => c.String());
            CreateIndex("dbo.HorasExtras", "tipoHoraExtraId");
            AddForeignKey("dbo.HorasExtras", "tipoHoraExtraId", "dbo.TipoHoraExtras", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HorasExtras", "tipoHoraExtraId", "dbo.TipoHoraExtras");
            DropIndex("dbo.HorasExtras", new[] { "tipoHoraExtraId" });
            DropColumn("dbo.HorasExtras", "TipoHoraExtraNombre");
            DropColumn("dbo.HorasExtras", "tipoHoraExtraId");
        }
    }
}
