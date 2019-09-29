using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estacionamentoApp.Model
{
    class Vaga
    {
        [Key]
        public int idVaga { get; set; }
        public bool disponivel { get; set; }
        public DateTime ocupadoDesde { get; set; }
        //public List<RegistroCarro> RegistroCarro { get; set; }
        public List<RegistroCarro> RegistroCarro { get; set; }


        public virtual string vagaNome
        {
            get
            {
                return Convert.ToString("A" + idVaga);
            }
        }
        public virtual string dispo
        {
            get
            {
                if (disponivel != false)
                {
                    return "LIVRE";
                }
                else
                {
                    return "OCUPADA";
                }
            }
        }
    }
}
