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

namespace estacionamentoApp
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CadastroCrro_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new View.Cadastro.CadastroCarro();
        }

        private void CadastroCliente_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new View.CadastrarCliente();
        }

        private void ListarCarro_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new View.Listar.ListarCarros();
        }

        private void ListarCliente_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new View.Listar.ListarClientes();
        }

        private void EditarCliente_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new View.Editar.EDCliente();
        }

        private void ValoresEst_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new View.Cadastro.CADValores();
        }

        private void EditarCarro_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new View.Editar.EDCarro();
        }

        private void Vagas_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new View.Cadastro.CadastroVaga();
        }

        private void VagasOn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new View.EntradaVeiculo();
        }
    }
}
