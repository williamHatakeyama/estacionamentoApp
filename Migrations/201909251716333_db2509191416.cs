namespace estacionamentoApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class db2509191416 : DbMigration
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
                        Cliente_idCliente = c.Int(),
                    })
                .PrimaryKey(t => t.idRegistro)
                .ForeignKey("dbo.Carroes", t => t.Carro_idCarro)
                .ForeignKey("dbo.Clientes", t => t.Cliente_idCliente)
                .Index(t => t.Carro_idCarro)
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegistroCarroes", "Cliente_idCliente", "dbo.Clientes");
            DropForeignKey("dbo.RegistroCarroes", "Carro_idCarro", "dbo.Carroes");
            DropForeignKey("dbo.Carroes", "Clientes_idCliente", "dbo.Clientes");
            DropIndex("dbo.RegistroCarroes", new[] { "Cliente_idCliente" });
            DropIndex("dbo.RegistroCarroes", new[] { "Carro_idCarro" });
            DropIndex("dbo.Carroes", new[] { "Clientes_idCliente" });
            DropTable("dbo.RegistroValors");
            DropTable("dbo.RegistroCarroes");
            DropTable("dbo.Clientes");
            DropTable("dbo.Carroes");
        }
    }
}
