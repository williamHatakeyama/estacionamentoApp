namespace estacionamentoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db280920192330 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carroes",
                c => new
                    {
                        idCarro = c.Int(nullable: false, identity: true),
                        placa = c.String(),
                        cor = c.String(),
                        ano = c.Int(nullable: false),
                        modelo = c.String(),
                        CriadoEm = c.DateTime(nullable: false),
                        Clientes_idCliente = c.Int(),
                    })
                .PrimaryKey(t => t.idCarro)
                .ForeignKey("dbo.Clientes", t => t.Clientes_idCliente)
                .Index(t => t.Clientes_idCliente);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        idCliente = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        sobrenome = c.String(),
                        cpf = c.String(),
                        telefone = c.String(),
                        idade = c.Int(nullable: false),
                        CriadoEm = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idCliente);
            
            CreateTable(
                "dbo.RegistroCarroes",
                c => new
                    {
                        idRegistro = c.Int(nullable: false, identity: true),
                        horaEntrada = c.DateTime(nullable: false),
                        horaSaida = c.DateTime(nullable: false),
                        valorTotal = c.Double(nullable: false),
                        Carro_idCarro = c.Int(),
                        RegistroValor_idValor = c.Int(),
                        vaga_idVaga = c.Int(),
                    })
                .PrimaryKey(t => t.idRegistro)
                .ForeignKey("dbo.Carroes", t => t.Carro_idCarro)
                .ForeignKey("dbo.RegistroValors", t => t.RegistroValor_idValor)
                .ForeignKey("dbo.Vagas", t => t.vaga_idVaga)
                .Index(t => t.Carro_idCarro)
                .Index(t => t.RegistroValor_idValor)
                .Index(t => t.vaga_idVaga);
            
            CreateTable(
                "dbo.RegistroValors",
                c => new
                    {
                        idValor = c.Int(nullable: false, identity: true),
                        valorMinuto = c.Double(nullable: false),
                        valorMeiaHora = c.Double(nullable: false),
                        valorHora = c.Double(nullable: false),
                        valorData = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idValor);
            
            CreateTable(
                "dbo.Vagas",
                c => new
                    {
                        idVaga = c.Int(nullable: false, identity: true),
                        disponivel = c.Boolean(nullable: false),
                        ocupadoDesde = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.idVaga);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegistroCarroes", "vaga_idVaga", "dbo.Vagas");
            DropForeignKey("dbo.RegistroCarroes", "RegistroValor_idValor", "dbo.RegistroValors");
            DropForeignKey("dbo.RegistroCarroes", "Carro_idCarro", "dbo.Carroes");
            DropForeignKey("dbo.Carroes", "Clientes_idCliente", "dbo.Clientes");
            DropIndex("dbo.RegistroCarroes", new[] { "vaga_idVaga" });
            DropIndex("dbo.RegistroCarroes", new[] { "RegistroValor_idValor" });
            DropIndex("dbo.RegistroCarroes", new[] { "Carro_idCarro" });
            DropIndex("dbo.Carroes", new[] { "Clientes_idCliente" });
            DropTable("dbo.Vagas");
            DropTable("dbo.RegistroValors");
            DropTable("dbo.RegistroCarroes");
            DropTable("dbo.Clientes");
            DropTable("dbo.Carroes");
        }
    }
}
