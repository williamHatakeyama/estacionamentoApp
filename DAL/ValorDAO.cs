using estacionamentoApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estacionamentoApp.DAL
{
    class ValorDAO
    {

        //Any(): é método que retorna se existe 
        //algum registro na busca
        //Count(): é método que retorna a quantidade
        //itens dentro de uma busca
        // ctx.Vendas.Include("Cliente").Include("Vendedor").Include("RegistroValor.Produto.Categoria").ToList();

        private static Context ctx = SingletonContext.GetInstance();
        public static void CadastrarRegistroValor(RegistroValor p)
        {
            ctx.RegistroValor.Add(p);
            ctx.SaveChanges();
        }
        public static List<RegistroValor> ListarRegistroValor() => ctx.RegistroValor.ToList();

        public static int UltimoRegistroValor()
        {
            int x  = ListarRegistroValor().Last().idValor;
            if (x != 0 )
            {
                return x;
            }
            else
            {
                return 0;
            }
        }
        
        public static RegistroValor BuscarRegistroValorPorData(DateTime data)
        {
            return ctx.RegistroValor.FirstOrDefault
                (x => x.valorData.Day == data.Day &&
                    x.valorData.Month == data.Month &&
                    x.valorData.Year == data.Year);
        }
        public static void RemoverRegistroValor(RegistroValor p)
        {
            ctx.RegistroValor.Remove(p);
            ctx.SaveChanges();
        }
        public static void AlterarRegistroValor(RegistroValor p)
        {
            ctx.Entry(p).State = EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
