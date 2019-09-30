using estacionamentoApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estacionamentoApp.DAL
{
    class RegistroCarroDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarRegCarro(RegistroCarro r)
        {
            try
            {
                ctx.RegistroCarro.Add(r);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public static List<RegistroCarro> ListarRegCarros() => ctx.RegistroCarro.Include("Vaga").Include("Carro").Include("RegistroValor").ToList();
        public static List<RegistroCarro> ListarRegCarrosEstacionados()
        {
            return ctx.RegistroCarro.Include("Vaga").Include("Carro").Include("RegistroValor").Where(x => x.on == true).ToList();

        }
        public static bool ValidaSeTemReg()
        {
            int x = ctx.RegistroCarro.Count();
            if (x == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void AlterarRegistroCarro(RegistroCarro p)
        {
            ctx.Entry(p).State = EntityState.Modified;
            ctx.SaveChanges();
        }


        public static RegistroCarro BuscarRegistroPorId(int p)
        {
            //FirstOrDefault: é o metodo que retorna o
            //PRIMEIRO objeto na busca
            return ctx.RegistroCarro.FirstOrDefault(x => x.idRegistro == p);

            //SingleOrDefault: é o metodo que retorna um
            //ÚNICO objeto na busca 
            //return ctx.Carros.SingleOrDefault
            //    (x => x.Nome.Equals(p.Nome));
        }

    }
}
