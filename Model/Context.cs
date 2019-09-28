using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estacionamentoApp.Model
{
    class Context : DbContext
    {

        public Context() : base("DbGeral") { }

        //Definir as classes que vão tabelas no banco
        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<RegistroCarro> RegistroCarro { get; set; }
        public DbSet<RegistroValor> RegistroValor { get; set; }

    }
}
