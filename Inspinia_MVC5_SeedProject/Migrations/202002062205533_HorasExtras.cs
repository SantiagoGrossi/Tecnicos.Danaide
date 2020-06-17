namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HorasExtras : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HorasExtras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.String(maxLength: 128),
                        Cantidad = c.Int(nullable: false),
                        NumeroMes = c.Int(nullable: false),
                        NombreMes = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioId)
                .Index(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HorasExtras", "UsuarioId", "dbo.AspNetUsers");
            DropIndex("dbo.HorasExtras", new[] { "UsuarioId" });
            DropTable("dbo.HorasExtras");
        }
    }
}
