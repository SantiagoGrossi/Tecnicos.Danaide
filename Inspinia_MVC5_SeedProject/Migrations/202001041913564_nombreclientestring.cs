namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nombreclientestring : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TareasDiarias", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.TareasDiarias", new[] { "ClienteId" });
            AddColumn("dbo.TareasDiarias", "NombreCliente", c => c.String());
            DropColumn("dbo.TareasDiarias", "ClienteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TareasDiarias", "ClienteId", c => c.Int(nullable: false));
            DropColumn("dbo.TareasDiarias", "NombreCliente");
            CreateIndex("dbo.TareasDiarias", "ClienteId");
            AddForeignKey("dbo.TareasDiarias", "ClienteId", "dbo.Clientes", "Id", cascadeDelete: true);
        }
    }
}
