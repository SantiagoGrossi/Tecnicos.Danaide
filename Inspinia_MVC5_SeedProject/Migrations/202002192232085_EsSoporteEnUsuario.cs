namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EsSoporteEnUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "EsSoporte", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "EsSoporte");
        }
    }
}
