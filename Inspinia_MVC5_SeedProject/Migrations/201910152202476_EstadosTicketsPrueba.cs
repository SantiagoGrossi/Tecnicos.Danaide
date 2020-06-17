namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EstadosTicketsPrueba : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EstadosTickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Estado = c.String(),
                        isActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EstadosTickets");
        }
    }
}
