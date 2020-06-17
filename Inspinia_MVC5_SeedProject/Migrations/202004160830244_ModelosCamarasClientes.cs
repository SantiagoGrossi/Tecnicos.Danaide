namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelosCamarasClientes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CamarasMalvinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCamara = c.String(),
                        Ip = c.String(),
                        TieneVideo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CamarasMalvinas");
        }
    }
}
