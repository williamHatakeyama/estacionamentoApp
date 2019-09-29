using estacionamentoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace estacionamentoApp.View.Cadastro
{
    /// <summary>
    /// Interação lógica para CADValores.xam
    /// </summary>
    public partial class CADValores : UserControl
    {
        public CADValores()
        {



            InitializeComponent();
            textIDV.Text = "123321";
          
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            RegistroValor rValor = new RegistroValor();
            rValor.valorMinuto = Convert.ToDouble(txtMinuto.Text);
            rValor.valorMeiaHora = Convert.ToDouble(txtMeiaHora.Text);
            rValor.valorHora = Convert.ToDouble(txtHora.Text);
            rValor.valorData = DateTime.Now;
            try
            {
                DAL.ValorDAO.CadastrarRegistroValor(rValor);
                MessageBox.Show("Cliente cadastrado com sucesso!",
                                   "Estacionamento App",
                                     MessageBoxButton.OK,
                                      MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Cliente não cadastrado!",
                                   "Estacionamento App",
                                     MessageBoxButton.OK,
                                      MessageBoxImage.Information);
                throw;
            }

        }
    }
}
