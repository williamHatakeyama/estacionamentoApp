using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estacionamentoApp.Model
{
    class RegistroCarro
    {
        [Key]
        public int idRegistro { get; set; }
        public Carro Carro { get; set; }
        public Vaga vaga { get; set; }
        public RegistroValor RegistroValor { get; set; }
        public DateTime horaEntrada { get; set; }
        public DateTime horaSaida { get; set; }
        public double valorTotal { get; set; }
    }
}
