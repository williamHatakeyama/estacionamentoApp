using estacionamentoApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estacionamentoApp.DAL
{
    class CarroDAO
    {
        //Any(): é método que retorna se existe 
        //algum registro na busca
        //Count(): é método que retorna a quantidade
        //itens dentro de uma busca
        // ctx.Vendas.Include("Cliente").Include("Vendedor").Include("Carros.Produto.Categoria").ToList();

        private static Context ctx = SingletonContext.GetInstance();
        public static void CadastrarCarro(Carro p)
        {
            ctx.Carros.Add(p);
            ctx.SaveChanges();
        }
        public static List<Carro> ListarCarros() => ctx.Carros.Include("Clientes").ToList();
        public static Carro BuscarCarroPorPlaca(Carro p)
        {
            //FirstOrDefault: é o metodo que retorna o
            //PRIMEIRO objeto na busca
            return ctx.Carros.FirstOrDefault
                (x => x.placa.Equals(p.placa));

            //SingleOrDefault: é o metodo que retorna um
            //ÚNICO objeto na busca 
            //return ctx.Carros.SingleOrDefault
            //    (x => x.Nome.Equals(p.Nome));
        }

        public static Carro BuscarCarroPorPlacaString(string p)
        {
            return ctx.Carros.FirstOrDefault
                (x => x.placa.Equals(p));
        }
        public static Carro BuscarCarroPorData(DateTime data)
        {
            return ctx.Carros.FirstOrDefault
                (x => x.CriadoEm.Day == data.Day &&
                    x.CriadoEm.Month == data.Month &&
                    x.CriadoEm.Year == data.Year);
        }
        public static List<Carro> BuscarCarrosPorPartePlaca(Carro p)
        {
            //Where: é método que retorna todas as
            //ocorrências em uma busca
            return ctx.Carros.Where
                (x => x.placa.Contains(p.placa)).ToList();
        }
        //public static double CalcularValorEstoque()
        //{
        //    return ctx.Carros.Sum
        //        (x => x.Quantidade * x.Preco);
        //}
        public static void RemoverCarro(Carro p)
        {
            ctx.Carros.Remove(p);
            ctx.SaveChanges();
        }
        public static void AlterarCarro(Carro p)
        {
            ctx.Entry(p).State = EntityState.Modified;
            ctx.SaveChanges();
        }

    }
}
