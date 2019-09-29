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
        public Vaga Vaga { get; set; }
        public RegistroValor RegistroValor { get; set; }
        public DateTime horaEntrada { get; set; }
        public DateTime horaSaida { get; set; }
        public double valorTotal { get; set; }


        public virtual string placa
        {
            get
            {
                return Carro.placaR;
            }
        }
        public virtual string cliente
        {
            get
            {
                return Convert.ToString(Carro.Clientes.nome + " " + Carro.Clientes.nome);
            }
        }
        public virtual string disponivel
        {
            get
            {
                return Convert.ToString(Vaga.disponivel);
            }
        }

    }
}
