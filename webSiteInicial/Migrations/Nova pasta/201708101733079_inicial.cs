namespace webSiteInicial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bandas",
                c => new
                    {
                        idBanda = c.Int(nullable: false, identity: true),
                        NomeBanda = c.String(),
                    })
                .PrimaryKey(t => t.idBanda);
            
            AddColumn("dbo.Musicoes", "BandaPrincipal_idBanda", c => c.Int());
            CreateIndex("dbo.Musicoes", "BandaPrincipal_idBanda");
            AddForeignKey("dbo.Musicoes", "BandaPrincipal_idBanda", "dbo.Bandas", "idBanda");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musicoes", "BandaPrincipal_idBanda", "dbo.Bandas");
            DropIndex("dbo.Musicoes", new[] { "BandaPrincipal_idBanda" });
            DropColumn("dbo.Musicoes", "BandaPrincipal_idBanda");
            DropTable("dbo.Bandas");
        }
    }
}
