using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WAssociado.SAssociado;


namespace WAssociado
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void mnuAssociado_Click(object sender, RoutedEventArgs e)
        {
            frmAssociado form = new frmAssociado();
            form.ShowDialog();
        }

        private void mnuMensalidade_Click(object sender, RoutedEventArgs e)
        {
            frmMensalidade form = new frmMensalidade();
            form.ShowDialog();
        }

        private void mnuListarMensalidade_Click(object sender, RoutedEventArgs e)
        {
            frmListaMensalidade form = new frmListaMensalidade();
            form.ShowDialog();
        }
    }
}
