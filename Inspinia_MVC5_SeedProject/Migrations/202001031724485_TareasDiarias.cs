namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TareasDiarias : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TareasDiarias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Resumen = c.String(),
                        Descripcion = c.String(),
                        Minutos = c.Int(),
                        FechaCreada = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        Finalizada = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TareasDiarias", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.TareasDiarias", new[] { "ClienteId" });
            DropTable("dbo.TareasDiarias");
        }
    }
}
