namespace webSiteInicial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class premera : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Musicoes", "BandaPrincipal_idBanda", "dbo.Bandas");
            DropIndex("dbo.Musicoes", new[] { "BandaPrincipal_idBanda" });
            RenameColumn(table: "dbo.Musicoes", name: "BandaPrincipal_idBanda", newName: "BandaPrincipalID");
            AlterColumn("dbo.Musicoes", "BandaPrincipalID", c => c.Int(nullable: false));
            CreateIndex("dbo.Musicoes", "BandaPrincipalID");
            AddForeignKey("dbo.Musicoes", "BandaPrincipalID", "dbo.Bandas", "idBanda", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Musicoes", "BandaPrincipalID", "dbo.Bandas");
            DropIndex("dbo.Musicoes", new[] { "BandaPrincipalID" });
            AlterColumn("dbo.Musicoes", "BandaPrincipalID", c => c.Int());
            RenameColumn(table: "dbo.Musicoes", name: "BandaPrincipalID", newName: "BandaPrincipal_idBanda");
            CreateIndex("dbo.Musicoes", "BandaPrincipal_idBanda");
            AddForeignKey("dbo.Musicoes", "BandaPrincipal_idBanda", "dbo.Bandas", "idBanda");
        }
    }
}
