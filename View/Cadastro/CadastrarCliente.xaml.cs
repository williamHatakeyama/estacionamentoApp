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

namespace estacionamentoApp.View
{
    /// <summary>
    /// Interação lógica para CadastrarCliente.xam
    /// </summary>
    public partial class CadastrarCliente : UserControl
    {
        public CadastrarCliente()
        {
            InitializeComponent();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (!txtNome.Text.Equals("") && !txtSobrenome.Text.Equals("") && !txtTelefone.Text.Equals("") &&  !txtIdade.Text.Equals("") && !txtCPF.Text.Equals("") && !txtSexo.Text.Equals(""))
            {


                Cliente c = new Cliente();
                c.nome = txtNome.Text;
                c.sobrenome = txtSobrenome.Text;
                c.cpf = txtCPF.Text;
                c.telefone = txtTelefone.Text;
                c.sexo = txtSexo.Text;
                c.idade = Convert.ToInt32(txtIdade.Text);
                c.CriadoEm = DateTime.Now;
                try
                {
                    DAL.ClienteDAO.CadastrarCliente(c);
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
            else
            {
                MessageBox.Show("preencha todos campos!");
            }
        }
    }
}
