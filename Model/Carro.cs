using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estacionamentoApp.Model
{
    class Carro
    {
        [Key]
        public int idCarro { get; set; }
        public string placa { get; set; }
        public string cor { get; set; }
        public int ano { get; set; }
        public string modelo { get; set; }
        public Cliente Clientes { get; set; }
        public List<RegistroCarro> RegistroCarro { get; set; }
        //public RegistroCarro registroCarro { get; set; }
        public DateTime CriadoEm { get; set; }

        public virtual string placaR
        {
            get
            {
                return Convert.ToString(placa);
            }
        }
        public virtual string idCliente
        {
            get
            {
                return Convert.ToString(Clientes.idCliente);
            }
        }
        public virtual string nomeCompletoCliente
        {
            get
            {
                return Convert.ToString(Clientes.nome+" "+Clientes.sobrenome);
            }
        }

    }
}
