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
    public partial class Pes_Associado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Primeira vez que executo a minha página
                if(!Page.IsPostBack)
                {
                    CarregarGrid();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CarregarGrid()
        {
            //Carregar a grid
            NAssociado nAssociado = new NAssociado();
            EAssociado eAssociado = new EAssociado();
            List<EAssociado> lstRetorno = nAssociado.Listar(eAssociado);

            grdPesquisa.DataSource = lstRetorno;
            grdPesquisa.DataBind();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                //Declara as variáveis
                NAssociado nAssociado = new NAssociado();
                EAssociado eAssociado = new EAssociado();

                //Recupera o parametro
                eAssociado.nome = txtNome.Text;

                //Executa o método lista da classe de negócio
                List<EAssociado> lstRetorno = nAssociado.Listar(eAssociado);

                grdPesquisa.DataSource = lstRetorno;
                grdPesquisa.DataBind();


            }
            catch (Exception)
            {
                
                throw;
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("~/Paginas/CAD_Associado.aspx?Acao=I");
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void grdPesquisa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           if (e.Row.RowType == DataControlRowType.DataRow)
           {
               e.Row.Attributes.Add("style", "cursor:pointer;");
               e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference((System.Web.UI.Control)sender, "Select$" + e.Row.RowIndex.ToString()));
           }            
        }

        protected void grdPesquisa_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow linhaSelecionada = this.grdPesquisa.SelectedRow;
            string x = linhaSelecionada.Cells[1].Text;

            Response.Redirect("~/Paginas/CAD_Associado.aspx?Acao=A&id=" + x);

        }

        protected void grdPesquisa_RowCreated(object sender, GridViewRowEventArgs e)
        {
           if (e.Row.RowType == DataControlRowType.DataRow)
           {
               grdPesquisa.Columns[0].Visible = false;
           }
        }

        protected void grdPesquisa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdPesquisa.PageIndex = e.NewPageIndex;
                CarregarGrid();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}