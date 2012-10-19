using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using Entidade;

namespace Negocio
{
    public class NTipoAssociado
    {
        PTipoAssociado pTipoAssociado = new PTipoAssociado();

        public ETipoAssociado Consultar(int identificador)
        {
            try
            {
                return pTipoAssociado.Consultar(identificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ETipoAssociado> Listar()
        {
            try
            {
                return pTipoAssociado.Listar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
