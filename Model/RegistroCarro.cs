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
        public bool on{ get; set; }
        public Carro Carro { get; set; }
        public Vaga Vaga { get; set; }
        public RegistroValor RegistroValor { get; set; }
        public DateTime horaEntrada { get; set; }
        public DateTime horaSaida { get; set; }
        public double valorTotal { get; set; }

        public virtual string vagaON
        {
            get
            {
                if (on == true)
                {
                    return Convert.ToString("Ativo");
                }
                else
                {
                    return Convert.ToString("Desativado");
                }
                
            }
        }
        public virtual string idVaga
        {
            get
            {
                return Convert.ToString(Vaga.idVaga);
            }
        }
        public virtual string idCarro
        {
            get
            {
                return Convert.ToString(Carro.idCarro);
            }
        }
        public virtual string placa
        {
            get
            {
                return Carro.placaR;
            }
        }
        public virtual string disponivel
        {
            get
            {
                return Convert.ToString(Vaga.disponivel);
            }
        }
        public virtual string idValor
        {
            get
            {
                return Convert.ToString(RegistroValor.idValor);
            }
        }
    }
}
