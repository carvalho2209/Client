using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidade;


namespace Apresentacao.Paginas
{
    public partial class Cad_Associado : System.Web.UI.Page
    {
        #region métodos
        private void SalvarAssociado()
        {
            //Preencher a entidade
            EAssociado associado = new EAssociado();
            associado.nome = txtNome.Text;
            associado.endereco = txtEndereco.Text;
            associado.telefone = txtTelefone.Text;
            associado.tipoAssociado.identificador =
                int.Parse(ddlTipoAssociado.SelectedValue);

            NAssociado ngAssociado = new NAssociado();
            if (txtIdentificador.Text == string.Empty)
            {
                //Executar o método incluir
                associado = ngAssociado.Incluir(associado);
            }
            else
            {
                //O identificador está preenchido
                //Executar o método de alteração
                associado.identificador = int.Parse(txtIdentificador.Text);
                ngAssociado.Alterar(associado);
            }

            RetornarPagina();
        }

        private void CarregarTipoAssociado()
        {
            NTipoAssociado ngTipoAssociado = new NTipoAssociado();
            List<ETipoAssociado> lstRetorno = ngTipoAssociado.Listar();

            ddlTipoAssociado.DataSource = lstRetorno;
            ddlTipoAssociado.DataBind();
        }

        private void RetornarPagina()
        {
            //Retorna para a pagina de pesquisa
            Response.Redirect("~/Paginas/PES_Associado.aspx");
        }
        
        private void PreencherTela()
        {
            int id = int.Parse(Page.Request.QueryString["id"]);

            EAssociado associado = new EAssociado();
            NAssociado ngAssociado = new NAssociado();
            associado = ngAssociado.Consultar(id);

            txtIdentificador.Text = associado.identificador.ToString();
            txtNome.Text = associado.nome;
            txtEndereco.Text = associado.endereco;
            txtTelefone.Text = associado.telefone;

            ddlTipoAssociado.SelectedValue = associado.tipoAssociado.identificador.ToString();
        }
        #endregion métodos

        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    //Carrega a dropdown list com o método da classe de negócio
                    CarregarTipoAssociado();

                    //Recupera o id vindo da URL
                    if (Page.Request.QueryString["id"] != null)
                    {
                        PreencherTela();
                    }

                    //Preparar os botões da tela
                    if (Page.Request.QueryString["Acao"] != null)
                    {
                        #region tratar a ação da tela
                        if (Page.Request.QueryString["Acao"] == "I")
                        {
                            btnIncluir.Enabled = true;
                            btnAlterar.Enabled = false;
                            btnExcluir.Enabled = false;
                        }
                        else if (Page.Request.QueryString["Acao"] == "A")
                        {
                            btnIncluir.Enabled = false;
                            btnAlterar.Enabled = true;
                            btnExcluir.Enabled = true;
                        }
                        #endregion tratar a ação da tela

                    }
                    else
                    {
                        btnIncluir.Enabled = false;
                        btnAlterar.Enabled = false;
                        btnExcluir.Enabled = false;
                    }
                }

                
            }
            catch (Exception)
            {
                throw;
            }
        }
      
        protected void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                SalvarAssociado();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                SalvarAssociado();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                //Declara os objetos
                NAssociado ngAssociado = new NAssociado();
                if(!string.IsNullOrEmpty(txtIdentificador.Text))
                {
                    ngAssociado.Excluir(int.Parse(txtIdentificador.Text));
                }

                RetornarPagina();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnFechar_Click(object sender, EventArgs e)
        {
            try
            {
                RetornarPagina();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion eventos
    }
}