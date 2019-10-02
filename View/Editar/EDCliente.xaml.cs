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
    /// Interação lógica para EDCliente.xam
    /// </summary>
    public partial class EDCliente : UserControl
    {
        public EDCliente()
        {
            InitializeComponent();
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Cliente c = DAL.ClienteDAO.BuscarClientePorCPFString(txtCPF.Text);
            try
            {
                DAL.CarroDAO.RemoverCarrosComCliente(c.idCliente);
                DAL.ClienteDAO.RemoverCliente(c);
                //remover todos carros tmb
                MessageBox.Show("Cliente removido com sucesso!",
                                   "Estacionamento App",
                                     MessageBoxButton.OK,
                                      MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Cliente não removido!",
                                   "Estacionamento App",
                                     MessageBoxButton.OK,
                                      MessageBoxImage.Information);
                throw;
            }
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            Cliente c = DAL.ClienteDAO.BuscarClientePorCPFString(txtCPF.Text);
            txtNome.Text = c.nome;
            txtSobrenome.Text = c.sobrenome;
            lblSexo.Text = c.sexo;
            txtTelefone.Text = c.telefone;
            txtIdade.Text = Convert.ToString(c.idade);
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            Cliente c = DAL.ClienteDAO.BuscarClientePorCPFString(txtCPF.Text);
            c.nome = txtNome.Text;
            c.sobrenome = txtSobrenome.Text;
            c.telefone = txtTelefone.Text;
            c.sexo = lblSexo.Text;
            c.idade = Convert.ToInt32(txtIdade.Text);
            
            try
            {
                DAL.ClienteDAO.AlterarCliente(c);
                //remover todos carros tmb
                MessageBox.Show("Cliente alterado com sucesso!",
                                   "Estacionamento App",
                                     MessageBoxButton.OK,
                                      MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Cliente não alterado!",
                                   "Estacionamento App",
                                     MessageBoxButton.OK,
                                      MessageBoxImage.Information);
                throw;
            }
        }
    }
}
