namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guardianombreclienteString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TareasGuardias", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.TareasGuardias", new[] { "ClienteId" });
            AddColumn("dbo.TareasGuardias", "NombreCliente", c => c.String());
            DropColumn("dbo.TareasGuardias", "ClienteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TareasGuardias", "ClienteId", c => c.Int(nullable: false));
            DropColumn("dbo.TareasGuardias", "NombreCliente");
            CreateIndex("dbo.TareasGuardias", "ClienteId");
            AddForeignKey("dbo.TareasGuardias", "ClienteId", "dbo.Clientes", "Id", cascadeDelete: true);
        }
    }
}
