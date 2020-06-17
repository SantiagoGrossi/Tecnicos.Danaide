namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambiosissue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "TiempoDedicado", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Issues", "TiempoDedicado");
        }
    }
}
