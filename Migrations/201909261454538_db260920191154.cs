namespace estacionamentoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db260920191154 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RegistroCarroes", "Cliente_idCliente", "dbo.Clientes");
            DropIndex("dbo.RegistroCarroes", new[] { "Cliente_idCliente" });
            CreateTable(
                "dbo.Vagas",
                c => new
                    {
                        idVaga = c.Int(nullable: false, identity: true),
                        disponivel = c.Boolean(nullable: false),
                        ocupadoDesde = c.DateTime(nullable: false),
                        Carro_idCarro = c.Int(),
                    })
                .PrimaryKey(t => t.idVaga)
                .ForeignKey("dbo.Carroes", t => t.Carro_idCarro)
                .Index(t => t.Carro_idCarro);
            
            AddColumn("dbo.RegistroCarroes", "RegistroValor_idValor", c => c.Int());
            AddColumn("dbo.RegistroCarroes", "vaga_idVaga", c => c.Int());
            CreateIndex("dbo.RegistroCarroes", "RegistroValor_idValor");
            CreateIndex("dbo.RegistroCarroes", "vaga_idVaga");
            AddForeignKey("dbo.RegistroCarroes", "RegistroValor_idValor", "dbo.RegistroValors", "idValor");
            AddForeignKey("dbo.RegistroCarroes", "vaga_idVaga", "dbo.Vagas", "idVaga");
            DropColumn("dbo.RegistroCarroes", "Cliente_idCliente");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegistroCarroes", "Cliente_idCliente", c => c.Int());
            DropForeignKey("dbo.RegistroCarroes", "vaga_idVaga", "dbo.Vagas");
            DropForeignKey("dbo.Vagas", "Carro_idCarro", "dbo.Carroes");
            DropForeignKey("dbo.RegistroCarroes", "RegistroValor_idValor", "dbo.RegistroValors");
            DropIndex("dbo.Vagas", new[] { "Carro_idCarro" });
            DropIndex("dbo.RegistroCarroes", new[] { "vaga_idVaga" });
            DropIndex("dbo.RegistroCarroes", new[] { "RegistroValor_idValor" });
            DropColumn("dbo.RegistroCarroes", "vaga_idVaga");
            DropColumn("dbo.RegistroCarroes", "RegistroValor_idValor");
            DropTable("dbo.Vagas");
            CreateIndex("dbo.RegistroCarroes", "Cliente_idCliente");
            AddForeignKey("dbo.RegistroCarroes", "Cliente_idCliente", "dbo.Clientes", "idCliente");
        }
    }
}
