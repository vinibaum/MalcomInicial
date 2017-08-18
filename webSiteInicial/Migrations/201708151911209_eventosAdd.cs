namespace webSiteInicial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eventosAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Eventoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                        Data = c.DateTime(nullable: false),
                        DobroDe = c.String(),
                        Dia = c.Int(nullable: false),
                        LinkFacebook = c.String(),
                        Ambiente = c.Int(nullable: false),
                        BandaAbertura_idBanda = c.Int(),
                        BandaPrincipal_idBanda = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Bandas", t => t.BandaAbertura_idBanda)
                .ForeignKey("dbo.Bandas", t => t.BandaPrincipal_idBanda)
                .Index(t => t.BandaAbertura_idBanda)
                .Index(t => t.BandaPrincipal_idBanda);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Eventoes", "BandaPrincipal_idBanda", "dbo.Bandas");
            DropForeignKey("dbo.Eventoes", "BandaAbertura_idBanda", "dbo.Bandas");
            DropIndex("dbo.Eventoes", new[] { "BandaPrincipal_idBanda" });
            DropIndex("dbo.Eventoes", new[] { "BandaAbertura_idBanda" });
            DropTable("dbo.Eventoes");
        }
    }
}
