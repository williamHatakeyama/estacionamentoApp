namespace estacionamentoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbfinal : DbMigration
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
                        on = c.Boolean(nullable: false),
                        horaEntrada = c.DateTime(nullable: false),
                        horaSaida = c.DateTime(nullable: false),
                        valorTotal = c.Double(nullable: false),
                        Carro_idCarro = c.Int(),
                        RegistroValor_idValor = c.Int(),
                        Vaga_idVaga = c.Int(),
                        Cliente_idCliente = c.Int(),
                    })
                .PrimaryKey(t => t.idRegistro)
                .ForeignKey("dbo.Carroes", t => t.Carro_idCarro)
                .ForeignKey("dbo.RegistroValors", t => t.RegistroValor_idValor)
                .ForeignKey("dbo.Vagas", t => t.Vaga_idVaga)
                .ForeignKey("dbo.Clientes", t => t.Cliente_idCliente)
                .Index(t => t.Carro_idCarro)
                .Index(t => t.RegistroValor_idValor)
                .Index(t => t.Vaga_idVaga)
                .Index(t => t.Cliente_idCliente);
            
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
            DropForeignKey("dbo.RegistroCarroes", "Cliente_idCliente", "dbo.Clientes");
            DropForeignKey("dbo.RegistroCarroes", "Vaga_idVaga", "dbo.Vagas");
            DropForeignKey("dbo.RegistroCarroes", "RegistroValor_idValor", "dbo.RegistroValors");
            DropForeignKey("dbo.RegistroCarroes", "Carro_idCarro", "dbo.Carroes");
            DropForeignKey("dbo.Carroes", "Clientes_idCliente", "dbo.Clientes");
            DropIndex("dbo.RegistroCarroes", new[] { "Cliente_idCliente" });
            DropIndex("dbo.RegistroCarroes", new[] { "Vaga_idVaga" });
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
