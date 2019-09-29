namespace estacionamentoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db290920190037 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.RegistroCarroes", new[] { "vaga_idVaga" });
            CreateIndex("dbo.RegistroCarroes", "Vaga_idVaga");
        }
        
        public override void Down()
        {
            DropIndex("dbo.RegistroCarroes", new[] { "Vaga_idVaga" });
            CreateIndex("dbo.RegistroCarroes", "vaga_idVaga");
        }
    }
}
