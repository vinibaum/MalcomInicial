namespace webSiteInicial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arteseventos3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ArteEventoes", "CaminhoArquivo", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ArteEventoes", "CaminhoArquivo", c => c.String(nullable: false));
        }
    }
}
