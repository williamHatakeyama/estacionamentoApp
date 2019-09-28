using estacionamentoApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estacionamentoApp.DAL
{
    class ClienteDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        //Any(): é método que retorna se existe 
        //algum registro na busca
        //Count(): é método que retorna a quantidade
        //itens dentro de uma busca
        // ctx.Vendas.Include("Cliente").Include("Vendedor").Include("Clientes.Cliente.Categoria").ToList();

        public static void CadastrarCliente(Cliente p)
        {
            ctx.Clientes.Add(p);
            ctx.SaveChanges();
        }
        public static List<Cliente> ListarClientes() => ctx.Clientes.ToList();
        public static Cliente BuscarClientePorCPF(Cliente p)
        {
            //FirstOrDefault: é o metodo que retorna o
            //PRIMEIRO objeto na busca
            return ctx.Clientes.FirstOrDefault
                (x => x.cpf.Equals(p.cpf));

            //SingleOrDefault: é o metodo que retorna um
            //ÚNICO objeto na busca
            //return ctx.Clientes.SingleOrDefault
            //    (x => x.cpf.Equals(p));
        }
        public static Cliente BuscarClientePorCPFString(string p)
        {
            return ctx.Clientes.SingleOrDefault
                (x => x.cpf.Equals(p));
        }
        public static Cliente BuscarClientePorData(DateTime data)
        {
            return ctx.Clientes.FirstOrDefault
                (x => x.CriadoEm.Day == data.Day &&
                    x.CriadoEm.Month == data.Month &&
                    x.CriadoEm.Year == data.Year);
        }
        public static List<Cliente> BuscarClientesPorParteNome(Cliente p)
        {
            //Where: é método que retorna todas as
            //ocorrências em uma busca
            return ctx.Clientes.Where
                (x => x.nome.Contains(p.nome)).ToList();
        }
        //public static int CalcularQtdCarro()
        //{
        //    return ctx.Carros.Count(x => x.Clientes.idCliente == x.);
        //}
        public static void RemoverCliente(Cliente p)
        {
            ctx.Clientes.Remove(p);
            ctx.SaveChanges();
        }
        public static void AlterarCliente(Cliente p)
        {
            ctx.Entry(p).State = EntityState.Modified;
            ctx.SaveChanges();
        }


    }
}
