namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SystemsToModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Systems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IpSystem = c.String(),
                        ClienteId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Systems", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Systems", new[] { "ClienteId" });
            DropTable("dbo.Systems");
        }
    }
}
