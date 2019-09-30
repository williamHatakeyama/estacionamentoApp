using estacionamentoApp.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interação lógica para EntradaVeiculo.xam
    /// </summary>
    public partial class EntradaVeiculo : UserControl
    {
        public EntradaVeiculo()
        {
            InitializeComponent();
            //bool result = DAL.RegistroCarroDAO.ValidaSeTemReg();
            //if (result == true)
            //{
            //    dtaVagas.ItemsSource = DAL.RegistroCarroDAO.ListarRegCarros();
            //}

        }

        private void BtnEstacionar_Click(object sender, RoutedEventArgs e)
        {
            Carro c = DAL.CarroDAO.BuscarCarroPorPlacaString(txtPLACAcarro.Text);
            if (c != null)
            {
                RegistroCarro registroCarro = new RegistroCarro();
                registroCarro.Carro = c;
                registroCarro.RegistroValor = DAL.ValorDAO.BuscaRegistroPorID(DAL.ValorDAO.UltimoRegistroValor());
                registroCarro.Vaga = DAL.VagaDAO.BuscarPrimeiraVagaLivre();
                registroCarro.horaEntrada = DateTime.Now;
                registroCarro.horaSaida = DateTime.Now;
                registroCarro.valorTotal = 0;
                registroCarro.on = true;
                //registroCarro.Vaga.disponivel = false;
                //DAL.VagaDAO.AlterarVaga(registroCarro.Vaga);
                bool x = DAL.RegistroCarroDAO.CadastrarRegCarro(registroCarro);

                if (x == true)
                {
                    UserControl_Loaded(sender,e);
                    MessageBox.Show("Estacionado com sucesso!",
                                   "Estacionamento App",
                                     MessageBoxButton.OK,
                                      MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Nao Estacionado!",
                                       "Estacionamento App",
                                         MessageBoxButton.OK,
                                          MessageBoxImage.Information);
                }
            }


        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dtaEV.ItemsSource = DAL.RegistroCarroDAO.ListarRegCarrosEstacionados();
        }


        private void DtaEV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dynamic d = dtaEV.SelectedItem;
            RegistroCarro r = DAL.RegistroCarroDAO.BuscarRegistroPorId(d.idRegistro);
            r.horaSaida = DateTime.Now;
            double minutoTotal = (r.horaSaida - r.horaEntrada).TotalMinutes;

            r.valorTotal = Convert.ToDouble((minutoTotal * r.RegistroValor.valorMinuto));
            MessageBox.Show(Convert.ToString(r.valorTotal));

            //MessageBox.Show(Convert.ToString(valorT));

            lblHE.Content = Convert.ToString(r.horaEntrada);
            lblHS.Content = Convert.ToString(r.horaSaida);
            lblPlaca.Content = d.Carro.placa;
            lblTotal.Content = Convert.ToString(r.valorTotal);
            DAL.RegistroCarroDAO.AlterarRegistroCarro(r);
        }

        private void BtnFecharCarro_Click(object sender, RoutedEventArgs e)
        {
            dynamic d = dtaEV.SelectedItem;
            RegistroCarro r = DAL.RegistroCarroDAO.BuscarRegistroPorId(d.idRegistro);
            r.on = false;
            DAL.RegistroCarroDAO.AlterarRegistroCarro(r);
            UserControl_Loaded(sender, e);
        }
    }
}
