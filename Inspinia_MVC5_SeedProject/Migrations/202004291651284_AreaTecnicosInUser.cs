namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AreaTecnicosInUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AreaTecnicosId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "AreaTecnicosId");
            AddForeignKey("dbo.AspNetUsers", "AreaTecnicosId", "dbo.AreaTecnicos", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "AreaTecnicosId", "dbo.AreaTecnicos");
            DropIndex("dbo.AspNetUsers", new[] { "AreaTecnicosId" });
            DropColumn("dbo.AspNetUsers", "AreaTecnicosId");
        }
    }
}
