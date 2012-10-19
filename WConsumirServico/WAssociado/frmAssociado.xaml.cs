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
using WAssociado.SAssociado;

namespace WAssociado
{
    /// <summary>
    /// Interaction logic for frmAssociado2.xaml
    /// </summary>
    public partial class frmAssociado : Window
    {
        public frmAssociado()
        {
            InitializeComponent();
        }
        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SAssociadoSoapClient sAssociado = new SAssociadoSoapClient();
                EAssociado eAssociado = new EAssociado();

                eAssociado = sAssociado.Consultar(int.Parse(txtIdentificador.Text));

                txtNome.Text = eAssociado.nome;
                txtEndereco.Text = eAssociado.endereco;
                txtTelefone.Text = eAssociado.telefone;
                txtTipoAssociado.Text = eAssociado.tipoAssociado.descricao;

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnConsultar2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EAssociado eAssociado = new EAssociado();
                SAssociadoSoapClient sAssociado = new SAssociadoSoapClient();
                sAssociado.ConsultarCompleted += new EventHandler<ConsultarCompletedEventArgs>(sAssociado_ConsultarCompleted);
                sAssociado.ConsultarAsync(int.Parse(txtIdentificador.Text));


            }
            catch (Exception)
            {
                throw;
            }
        }

        void sAssociado_ConsultarCompleted(object sender, ConsultarCompletedEventArgs e)
        {
            EAssociado eAssociado = e.Result;

            txtNome.Text = eAssociado.nome;
            txtEndereco.Text = eAssociado.endereco;
            txtTelefone.Text = eAssociado.telefone;
            txtTipoAssociado.Text = eAssociado.tipoAssociado.descricao;

        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
