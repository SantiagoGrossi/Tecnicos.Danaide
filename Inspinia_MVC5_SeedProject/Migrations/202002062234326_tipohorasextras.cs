namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tipohorasextras : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoHoraExtras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                        Valor = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TipoHoraExtras");
        }
    }
}
