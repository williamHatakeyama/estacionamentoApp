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
    /// Interação lógica para CadastroCarro.xam
    /// </summary>
    public partial class CadastroCarro : UserControl
    {
        public CadastroCarro()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtAno.Text.Equals("") && !txtCor.Text.Equals("") && !txtCpf.Text.Equals("") && !txtModelo.Text.Equals("") && !txtPlaca.Text.Equals(""))
            {


                Carro c = new Carro();
                Cliente cl = new Cliente();
                cl.cpf = txtCpf.Text;
                c.placa = txtPlaca.Text;
                c.cor = txtCor.Text;
                c.ano = Convert.ToInt32(txtAno.Text);
                c.modelo = txtModelo.Text;
                c.CriadoEm = DateTime.Now;
                cl = DAL.ClienteDAO.BuscarClientePorCPF(cl);
                if (cl != null)
                {
                    c.Clientes = cl;
                    DAL.CarroDAO.CadastrarCarro(c);
                    MessageBox.Show("Carro cadastrado com sucesso!",
                                       "Estacionamento App",
                                         MessageBoxButton.OK,
                                          MessageBoxImage.Information);
                }
                else
                {
                    DAL.CarroDAO.CadastrarCarro(c);
                    MessageBox.Show("Erro ao cadastrar!",
                                       "Estacionamento App",
                                         MessageBoxButton.OK,
                                          MessageBoxImage.Information);
                }
            }
        }

    }
}
