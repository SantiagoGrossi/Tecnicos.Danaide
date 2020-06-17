namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mensajes1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MensajesIssues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaCreado = c.DateTime(nullable: false),
                        IssueId = c.Int(nullable: false),
                        UsuarioId = c.String(maxLength: 128),
                        Mensaje = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Issues", t => t.IssueId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.IssueId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MensajesIssues", "UsuarioId", "dbo.AspNetUsers");
            DropForeignKey("dbo.MensajesIssues", "IssueId", "dbo.Issues");
            DropIndex("dbo.MensajesIssues", new[] { "UsuarioId" });
            DropIndex("dbo.MensajesIssues", new[] { "IssueId" });
            DropTable("dbo.MensajesIssues");
        }
    }
}
