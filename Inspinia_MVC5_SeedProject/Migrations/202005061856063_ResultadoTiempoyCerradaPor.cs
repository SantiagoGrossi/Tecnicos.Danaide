namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResultadoTiempoyCerradaPor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "CerradaPorId", c => c.String(maxLength: 128));
            AddColumn("dbo.Issues", "ResultadoTiempo", c => c.DateTime());
            CreateIndex("dbo.Issues", "CerradaPorId");
            AddForeignKey("dbo.Issues", "CerradaPorId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "CerradaPorId", "dbo.AspNetUsers");
            DropIndex("dbo.Issues", new[] { "CerradaPorId" });
            DropColumn("dbo.Issues", "ResultadoTiempo");
            DropColumn("dbo.Issues", "CerradaPorId");
        }
    }
}
