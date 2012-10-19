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
using WAssociado.SMensalidade;

namespace WAssociado
{
    /// <summary>
    /// Interaction logic for frmMensalidade.xaml
    /// </summary>
    public partial class frmMensalidade : Window
    {
        public frmMensalidade()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WAssociado.SAssociado.EAssociado eAssociado = new WAssociado.SAssociado.EAssociado();
                SAssociadoSoapClient sAssociado = new SAssociadoSoapClient();
                sAssociado.ConsultarCompleted += new EventHandler<SAssociado.ConsultarCompletedEventArgs>(sAssociado_ConsultarCompleted);
                sAssociado.ConsultarAsync(int.Parse(txtIdentificador.Text));

                txtReferencia.Text = DateTime.Now.ToString("yyyy/MM");
                txtDataVencimento.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
            catch (Exception)
            {
                throw;
            }
        }

        void sAssociado_ConsultarCompleted(object sender, SAssociado.ConsultarCompletedEventArgs e)
        {
            WAssociado.SAssociado.EAssociado eAssociado = e.Result;
            txtNome.Text = eAssociado.nome;
        }

        private void btnFechar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnIncluir_Click(object sender, RoutedEventArgs e)
        {
            SMensalidadeSoapClient sMensalidade = new SMensalidadeSoapClient();
            EMensalidade eMensalidade = new EMensalidade();

            eMensalidade.ID_Associado = int.Parse(txtIdentificador.Text);
            eMensalidade.Referencia = txtReferencia.Text;
            eMensalidade.ValorMensalidade = decimal.Parse(txtValorMensalidade.Text);
            eMensalidade.DataVencimento = DateTime.Parse(txtDataVencimento.Text);
            eMensalidade = (EMensalidade)sMensalidade.Incluir(eMensalidade);
        }
    }
}
