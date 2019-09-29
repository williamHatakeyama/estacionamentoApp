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
    /// Interação lógica para CadastroVaga.xam
    /// </summary>
    public partial class CadastroVaga : UserControl
    {
        public CadastroVaga()
        {
            InitializeComponent();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            bool resposta, resp;
            resposta = DAL.VagaDAO.RemoverVagasTodas();
            if (resposta)
            {
                resp = DAL.VagaDAO.CadastrarVagaVarias(Convert.ToInt32(txtVagas.Text));


                if (resp == true)
                {
                    MessageBox.Show("Gerado vagas com sucesso!",
                                       "Estacionamento App",
                                         MessageBoxButton.OK,
                                          MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Vagas não geradas!",
                                       "Estacionamento App",
                                         MessageBoxButton.OK,
                                          MessageBoxImage.Information);
                }
            }
        }

        private void BtnCadastrar1_Click(object sender, RoutedEventArgs e)
        {
            bool resp = DAL.VagaDAO.CadastrarVaga1(txtVaga1.Text);
            if (resp == true)
            {
                MessageBox.Show("Gerado vagas com sucesso!",
                                   "Estacionamento App",
                                     MessageBoxButton.OK,
                                      MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Vaga não gerada!",
                                   "Estacionamento App",
                                     MessageBoxButton.OK,
                                      MessageBoxImage.Information);
            }
        }
    }
}
