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

namespace estacionamentoApp.View.Listar
{
    /// <summary>
    /// Interação lógica para ListarCarros.xam
    /// </summary>
    public partial class ListarCarros : UserControl
    {
        public ListarCarros()
        {
            InitializeComponent();


            


        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dtgCarro.ItemsSource = DAL.CarroDAO.ListarCarros();
            dtgCarro.DisplayMemberPath = "Clientes";
        }
    }
}
