namespace webSiteInicial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arteseventos2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ArteEventoes", "Descricao", c => c.String(nullable: false));
            AlterColumn("dbo.ArteEventoes", "CaminhoArquivo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ArteEventoes", "CaminhoArquivo", c => c.String());
            AlterColumn("dbo.ArteEventoes", "Descricao", c => c.String());
        }
    }
}
