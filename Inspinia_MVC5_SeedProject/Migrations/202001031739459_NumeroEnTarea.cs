namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumeroEnTarea : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TareasDiarias", "Numero", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TareasDiarias", "Numero");
        }
    }
}
