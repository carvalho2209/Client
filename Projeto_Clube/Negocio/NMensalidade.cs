using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade;
using Persistencia;

namespace Negocio
{
    public class NMensalidade
    {
        //Declara o objeto da camada de persistência
        PMensalidade pMensalidade = new PMensalidade();

        public EMensalidade Incluir(EMensalidade mensalidade)
        {
            try
            {
                //Chama o método de inclusão
                mensalidade = pMensalidade.Incluir(mensalidade);

                //Retorna o objeto com o identificador preenchido
                return mensalidade;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public bool Alterar(EMensalidade mensalidade)
        {
            try
            {
                //Chama o método alterar da classe de persistencia
                return pMensalidade.Alterar(mensalidade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Excluir(int identificador)
        {
            try
            {
                return pMensalidade.Excluir(identificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public EMensalidade Consultar(int identificador)
        {
            try
            {
                return pMensalidade.Consultar(identificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EMensalidade> Listar(int idAssociado)
        {
            try
            {
                return pMensalidade.Listar(idAssociado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool VerificarMensalidadeEmAberto(int identificador)
        {
            try
            {
                return pMensalidade.VerificarMensalidadeEmAberto(identificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
