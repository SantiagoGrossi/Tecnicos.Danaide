namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class numeroenissue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Issues", "NumeroIssue", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Issues", "NumeroIssue");
        }
    }
}
