using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade;
using Persistencia;

namespace Negocio
{
    public class NAssociado
    {
        //Declara o objeto da camada de persistência
        PAssociado pAssociado = new PAssociado();

        public EAssociado Incluir(EAssociado associado)
        {
            try
            {
                ValidarAssociado(associado);

                //Chama o método de inclusão
                associado = pAssociado.Incluir(associado);

                //Retorna o objeto com o identificador preenchido
                return associado;
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }

        public bool Alterar(EAssociado associado)
        {
            try
            {
                //Valida o associado
                ValidarAssociado(associado);

                //Chama o método alterar da classe de persistencia
                return pAssociado.Alterar(associado);
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
                return pAssociado.Excluir(identificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public EAssociado Consultar(int identificador)
        {
            try
            {
                return pAssociado.Consultar(identificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EAssociado> Listar(EAssociado associado)
        {
            try
            {
                return pAssociado.Listar(associado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EAssociado> Listar()
        {
            try
            {
                EAssociado associado = new EAssociado();
                return this.Listar(associado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void ValidarAssociado(EAssociado associado)
        {
            if (associado.nome == "")
            {
                throw new Exception("É necessário preencher o nome do associado.");
            }
        }
    }
}
