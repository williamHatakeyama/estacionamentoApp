using estacionamentoApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estacionamentoApp.DAL
{
    class VagaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        //Any(): é método que retorna se existe 
        //algum registro na busca
        //Count(): é método que retorna a quantidade
        //itens dentro de uma busca
        // ctx.Vendas.Include("Vaga").Include("Vendedor").Include("Vagas.Vaga.Categoria").ToList();
        public static bool CadastrarVagaVarias(int q)
        {
            int qtd = 0;

            try
            {
                do
                {
                    Vaga vaga = new Vaga();
                    vaga.disponivel = true;
                    vaga.ocupadoDesde = DateTime.Now;
                    CadastrarVaga(vaga);
                    qtd++;
                } while (qtd < q);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }


        }
        public static bool CadastrarVaga1(string u)
        {
            if (u.Equals("uma"))
            {
                Vaga vaga = new Vaga();
                vaga.disponivel = true;
                vaga.ocupadoDesde = DateTime.Now;
                CadastrarVaga(vaga);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void CadastrarVaga(Vaga p)
        {
            ctx.Vagas.Add(p);
            ctx.SaveChanges();
        }
        public static List<Vaga> ListarVagas() => ctx.Vagas.ToList();
        public static Vaga BuscarVagaPorID(Vaga p)
        {
            //FirstOrDefault: é o metodo que retorna o
            //PRIMEIRO objeto na busca
            return ctx.Vagas.FirstOrDefault
                (x => x.idVaga.Equals(p.idVaga));

            //SingleOrDefault: é o metodo que retorna um
            //ÚNICO objeto na busca
            //return ctx.Vagas.SingleOrDefault
            //    (x => x.Nome.Equals(p.Nome));
        }


        //public static List<Vaga> BuscarVagasPorPlaca(Vaga p)
        //{
        //    //Where: é método que retorna todas as
        //    //ocorrências em uma busca
        //    return ctx.Vagas.Where
        //        (x => x.RegistroCarro.placa.Contains(p.RegistroCarro.Carro.placa)).ToList();
        //}
        //public static double CalcularValorEstoque()
        //{
        //    return ctx.Vagas.Sum
        //        (x => x.Quantidade * x.Preco);
        //}
        public static bool RemoverVagasTodas()
        {
            try
            {
                foreach (Vaga vaga in ListarVagas())
                {
                    RemoverVaga(vaga);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public static void RemoverVaga(Vaga p)
        {
            ctx.Vagas.Remove(p);
            ctx.SaveChanges();
        }
        public static void AlterarVaga(Vaga p)
        {
            ctx.Entry(p).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static Vaga BuscarPrimeiraVagaLivre()
        {
            Vaga vaga = ctx.Vagas.FirstOrDefault
                (x => x.disponivel == true);
            return vaga;

        }


    }
}
