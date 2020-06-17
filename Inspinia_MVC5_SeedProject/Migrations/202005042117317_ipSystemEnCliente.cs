namespace Inspinia_MVC5_SeedProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ipSystemEnCliente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "IpSystem", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "IpSystem");
        }
    }
}
