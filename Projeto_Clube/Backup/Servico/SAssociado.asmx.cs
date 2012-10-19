using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Negocio;
using Entidade;
using System.Threading;

namespace Servicos
{
    /// <summary>
    /// Summary description for SAssociado
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SAssociado : System.Web.Services.WebService
    {

        [WebMethod]
        public EAssociado Consultar(int idAssociado)
        {

            //Thread.Sleep(5000);

            NAssociado nAssociado = new NAssociado();
            return nAssociado.Consultar(idAssociado);
        }
    }
}
