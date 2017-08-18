namespace webSiteInicial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class artesAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArteEventoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        isArtePrincipal = c.Boolean(nullable: false),
                        Ativa = c.Boolean(nullable: false),
                        DataExpira = c.DateTime(),
                        CaminhoArquivo = c.String(),
                        EventoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Eventoes", t => t.EventoID, cascadeDelete: true)
                .Index(t => t.EventoID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArteEventoes", "EventoID", "dbo.Eventoes");
            DropIndex("dbo.ArteEventoes", new[] { "EventoID" });
            DropTable("dbo.ArteEventoes");
        }
    }
}
