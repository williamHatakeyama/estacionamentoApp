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

namespace estacionamentoApp.View.Editar
{
    /// <summary>
    /// Interação lógica para EDCarro.xam
    /// </summary>
    public partial class EDCarro : UserControl
    {
        public EDCarro()
        {
            InitializeComponent();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Carro c = DAL.CarroDAO.BuscarCarroPorPlacaString(txtPlaca.Text);
            txtCor.Text = c.cor;
            txtModelo.Text = c.modelo;
            txtAno.Text = Convert.ToString(c.ano);
        }

        private void BtnAltera_Click(object sender, RoutedEventArgs e)
        {
            Carro c = DAL.CarroDAO.BuscarCarroPorPlacaString(txtPlaca.Text);
            c.cor = txtCor.Text;
            c.modelo = txtModelo.Text;
            c.ano = Convert.ToInt32(txtAno.Text);

            try
            {
                DAL.CarroDAO.AlterarCarro(c);
                //remover todos carros tmb
                MessageBox.Show("carro excluido com sucesso!",
                                   "Estacionamento App",
                                     MessageBoxButton.OK,
                                      MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Carro não excluido!",
                                   "Estacionamento App",
                                     MessageBoxButton.OK,
                                      MessageBoxImage.Information);
                throw;
            }
        }

        private void BtnExclui_Click(object sender, RoutedEventArgs e)
        {
            Carro c = DAL.CarroDAO.BuscarCarroPorPlacaString(txtPlaca.Text);
            try
            {
                DAL.CarroDAO.RemoverCarro(c);
                //remover todos carros tmb
                MessageBox.Show("Carro removido com sucesso!",
                                   "Estacionamento App",
                                     MessageBoxButton.OK,
                                      MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Carro não removido!",
                                   "Estacionamento App",
                                     MessageBoxButton.OK,
                                      MessageBoxImage.Information);
                throw;
            }
        }
    }
}

