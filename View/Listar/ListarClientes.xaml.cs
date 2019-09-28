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

namespace estacionamentoApp.View.Listar
{
    /// <summary>
    /// Interação lógica para ListarClientes.xam
    /// </summary>
    public partial class ListarClientes : UserControl
    {
        public ListarClientes()
        {
            InitializeComponent();

            dtgCliente.ItemsSource = DAL.ClienteDAO.ListarClientes();
            dtgCliente.UpdateLayout();
        }

    }
}
