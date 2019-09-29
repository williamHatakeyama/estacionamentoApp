using estacionamentoApp.Model;
using System;
using System.Collections.Generic;
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

        //public static List<RegistroCarro> ListarRegCarros() => ctx.RegistroCarro.Include("Carro").Include("Cliente").ToList();
        public static List<RegistroCarro> ListarRegCarros() => ctx.RegistroCarro.Include("Carro").Include("Cliente").ToList(); //Include("Carro").ToList();

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

        //public static Cliente verificaListaVazia()
        //{
        //    ctx.RegistroCarro.FirstOrDefault(x=> x.idRegistro == x.)
        //    return ctx.Clientes.FirstOrDefault
        //        (x => x.cpf.Equals(p.cpf));

        //    //SingleOrDefault: é o metodo que retorna um
        //    //ÚNICO objeto na busca
        //    //return ctx.Clientes.SingleOrDefault
        //    //    (x => x.cpf.Equals(p));
        //}





    }
}
