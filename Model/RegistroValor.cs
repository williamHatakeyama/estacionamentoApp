using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estacionamentoApp.Model
{
    class RegistroValor
    {
        [Key]
        public int idValor { get; set; }
        public double valorMinuto { get; set; }
        public double valorMeiaHora { get; set; }
        public double valorHora { get; set; }
        public DateTime valorData { get; set; }
        //public RegistroCarro RegistroCarro { get; set; }

        public List<RegistroCarro> RegistroCarro { get; set; }

    }
}
