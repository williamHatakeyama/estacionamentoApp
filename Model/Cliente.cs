using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estacionamentoApp.Model
{
    class Cliente
    {
        [Key]
        public int idCliente { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public int idade { get; set; }
        public string sexo { get; set; }
        public List<Carro> Carros { get; set; }
        public List<RegistroCarro> registroCarros { get; set; }
        //public List<RegistroCarro> RegistroCarro { get; set; }
        public DateTime CriadoEm { get; set; }


        public virtual string nomeCliente
        {
            get
            {
                return Convert.ToString(nome + " " +sobrenome);
            }
        }

    }
}
