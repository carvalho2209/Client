using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Entidade;
using Negocio;

namespace Servicos
{
    /// <summary>
    /// Summary description for SMensalidade
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SMensalidade : System.Web.Services.WebService
    {
        NMensalidade nMensalidade;

        public SMensalidade()
        {
            nMensalidade = new NMensalidade();
        }

        [WebMethod]
        public EMensalidade Incluir(EMensalidade eMensalidade)
        {
            return nMensalidade.Incluir(eMensalidade);
        }

        [WebMethod]
        public bool Alterar(EMensalidade eMensalidade)
        {
            return nMensalidade.Alterar(eMensalidade);
        }

        [WebMethod]
        public bool Excluir(int codigoMensalidade)
        {
            return nMensalidade.Excluir(codigoMensalidade);
        }

        [WebMethod]
        public EMensalidade Consultar(int codigoMensalidade)
        {
            return nMensalidade.Consultar(codigoMensalidade);
        }

        [WebMethod]
        public List<EMensalidade> Listar(int codigoAssociado)
        {
            return nMensalidade.Listar(codigoAssociado);
        }

    }
}
