using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade
{
    [Serializable]
    public class EMovimentacaoClube
    {
        public EMovimentacaoClube()
        {
            Associado = new EAssociado();
        }

        public int Identficador_Movimentacao { get; set; }
        public int ID_Associado { get; set; }
        public DateTime DataHoraEntrada { get; set; }
        public DateTime ? DataHoraSaida { get; set; }
        public EAssociado Associado { get; set; }

    }
}
