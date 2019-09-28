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

        public static void CadastrarRegCarro(RegistroCarro r)
        {
            ctx.RegistroCarro.Add(r);
            ctx.SaveChanges();
        }

        public static List<RegistroCarro> ListarProdutos() => ctx.RegistroCarro.Include("Carro").Include("Cliente").ToList();




    }
}
