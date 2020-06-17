namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiosdb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Issues", "Clientes_Id", "dbo.Clientes");
            DropIndex("dbo.Issues", new[] { "Clientes_Id" });
            RenameColumn(table: "dbo.Issues", name: "Clientes_Id", newName: "ClientesId");
            RenameColumn(table: "dbo.Issues", name: "CreadaPor_Id", newName: "CreadaPorId");
            RenameColumn(table: "dbo.Issues", name: "DerivadaDe_Id", newName: "DerivadaDeId");
            RenameColumn(table: "dbo.Issues", name: "TecnicoAsignado_Id", newName: "TecnicoAsignadoId");
            RenameIndex(table: "dbo.Issues", name: "IX_DerivadaDe_Id", newName: "IX_DerivadaDeId");
            RenameIndex(table: "dbo.Issues", name: "IX_TecnicoAsignado_Id", newName: "IX_TecnicoAsignadoId");
            RenameIndex(table: "dbo.Issues", name: "IX_CreadaPor_Id", newName: "IX_CreadaPorId");
            AlterColumn("dbo.Issues", "ClientesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Issues", "ClientesId");
            AddForeignKey("dbo.Issues", "ClientesId", "dbo.Clientes", "Id", cascadeDelete: true);
            DropColumn("dbo.Issues", "DerivadaDeUserId");
            DropColumn("dbo.Issues", "TecnicoAsignadoUserId");
            DropColumn("dbo.Issues", "CreadaPorUserId");
            DropColumn("dbo.Issues", "ClienteId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Issues", "ClienteId", c => c.Int(nullable: false));
            AddColumn("dbo.Issues", "CreadaPorUserId", c => c.String());
            AddColumn("dbo.Issues", "TecnicoAsignadoUserId", c => c.String());
            AddColumn("dbo.Issues", "DerivadaDeUserId", c => c.String());
            DropForeignKey("dbo.Issues", "ClientesId", "dbo.Clientes");
            DropIndex("dbo.Issues", new[] { "ClientesId" });
            AlterColumn("dbo.Issues", "ClientesId", c => c.Int());
            RenameIndex(table: "dbo.Issues", name: "IX_CreadaPorId", newName: "IX_CreadaPor_Id");
            RenameIndex(table: "dbo.Issues", name: "IX_TecnicoAsignadoId", newName: "IX_TecnicoAsignado_Id");
            RenameIndex(table: "dbo.Issues", name: "IX_DerivadaDeId", newName: "IX_DerivadaDe_Id");
            RenameColumn(table: "dbo.Issues", name: "TecnicoAsignadoId", newName: "TecnicoAsignado_Id");
            RenameColumn(table: "dbo.Issues", name: "DerivadaDeId", newName: "DerivadaDe_Id");
            RenameColumn(table: "dbo.Issues", name: "CreadaPorId", newName: "CreadaPor_Id");
            RenameColumn(table: "dbo.Issues", name: "ClientesId", newName: "Clientes_Id");
            CreateIndex("dbo.Issues", "Clientes_Id");
            AddForeignKey("dbo.Issues", "Clientes_Id", "dbo.Clientes", "Id");
        }
    }
}
