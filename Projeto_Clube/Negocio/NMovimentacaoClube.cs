using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade;
using Persistencia;

namespace Negocio
{
    public class NMovimentacaoClube
    {
        //Declara o objeto da camada de persistência
        PMovimentacaoClube pMovimentacaoClube = new PMovimentacaoClube();


        public string RegistrarPassagem(int identificadorAssociado)
        {
            string strMensagem = string.Empty;

            //Verifica se o associado existe na base
            EAssociado associado = new NAssociado().Consultar(identificadorAssociado);
            if (string.IsNullOrEmpty(associado.nome))
                return strMensagem = "Associado não encontrado! Verifique o código digitado.";
                


            //Verifica se existe alguma mensalidade em aberto
            if (new NMensalidade().VerificarMensalidadeEmAberto(identificadorAssociado))
                return strMensagem = "Associado com Problemas no Cadastro! Procure a Administração.";


            //Registra a passagem verificando o sentido liberado
            EMovimentacaoClube movimentacao = new PMovimentacaoClube().ConsultarEntrada(identificadorAssociado);

            if (movimentacao.Identficador_Movimentacao == 0)
            {
                movimentacao.ID_Associado = identificadorAssociado;
                movimentacao.DataHoraEntrada = DateTime.Now;
                movimentacao = new PMovimentacaoClube().Incluir(movimentacao);
                strMensagem = "Entrada liberada!";
            }
            else
            {
                movimentacao.ID_Associado = identificadorAssociado;
                movimentacao.DataHoraSaida = DateTime.Now;
                bool b = new PMovimentacaoClube().Alterar(movimentacao);
                strMensagem = "Saida liberada!";
            }

            return strMensagem;
        }

    }
}
