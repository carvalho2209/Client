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
using System.Windows.Shapes;
using WAssociado.SMensalidade;
namespace WAssociado
{
    /// <summary>
    /// Interaction logic for frmListaMensalidade.xaml
    /// </summary>
    public partial class frmListaMensalidade : Window
    {
        public frmListaMensalidade()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SMensalidadeSoapClient sMensalidade = new SMensalidadeSoapClient();

                dtgMensalidades.ItemsSource = sMensalidade.Listar(int.Parse(txtIdentificador.Text));

                //sMensalidade.ListarCompleted += new EventHandler<ListarCompletedEventArgs>(sMensalidade_ListarCompleted);
                //sMensalidade.ListarAsync(int.Parse(txtIdentificador.Text));

            }
            catch (Exception)
            {
                throw;
            }
        }

        //void sMensalidade_ListarCompleted(object sender, ListarCompletedEventArgs e)
        //{
        //    List<EMensalidade> lstRetorno = new List<EMensalidade>();
        //    lstRetorno = e.Result.ToList();
        //    dtgMensalidades.ItemsSource = lstRetorno;
        //}

    }
}
