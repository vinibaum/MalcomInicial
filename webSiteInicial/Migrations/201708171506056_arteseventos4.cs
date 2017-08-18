namespace webSiteInicial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arteseventos4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Eventoes", "BandaAbertura_idBanda", "dbo.Bandas");
            DropForeignKey("dbo.Eventoes", "BandaPrincipal_idBanda", "dbo.Bandas");
            DropIndex("dbo.Eventoes", new[] { "BandaAbertura_idBanda" });
            DropIndex("dbo.Eventoes", new[] { "BandaPrincipal_idBanda" });
            RenameColumn(table: "dbo.Eventoes", name: "BandaAbertura_idBanda", newName: "BandaAberturaID");
            RenameColumn(table: "dbo.Eventoes", name: "BandaPrincipal_idBanda", newName: "BandaPrincipalID");
            AlterColumn("dbo.Eventoes", "BandaAberturaID", c => c.Int(nullable: false));
            AlterColumn("dbo.Eventoes", "BandaPrincipalID", c => c.Int(nullable: false));
            CreateIndex("dbo.Eventoes", "BandaAberturaID");
            CreateIndex("dbo.Eventoes", "BandaPrincipalID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Eventoes", "BandaPrincipalID", "dbo.Bandas");
            DropForeignKey("dbo.Eventoes", "BandaAberturaID", "dbo.Bandas");
            DropIndex("dbo.Eventoes", new[] { "BandaPrincipalID" });
            DropIndex("dbo.Eventoes", new[] { "BandaAberturaID" });
            AlterColumn("dbo.Eventoes", "BandaPrincipalID", c => c.Int());
            AlterColumn("dbo.Eventoes", "BandaAberturaID", c => c.Int());
            RenameColumn(table: "dbo.Eventoes", name: "BandaPrincipalID", newName: "BandaPrincipal_idBanda");
            RenameColumn(table: "dbo.Eventoes", name: "BandaAberturaID", newName: "BandaAbertura_idBanda");
            CreateIndex("dbo.Eventoes", "BandaPrincipal_idBanda");
            CreateIndex("dbo.Eventoes", "BandaAbertura_idBanda");
            AddForeignKey("dbo.Eventoes", "BandaPrincipal_idBanda", "dbo.Bandas", "idBanda");
            AddForeignKey("dbo.Eventoes", "BandaAbertura_idBanda", "dbo.Bandas", "idBanda");
        }
    }
}
