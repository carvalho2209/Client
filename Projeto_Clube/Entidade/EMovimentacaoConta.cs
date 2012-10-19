using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade
{
    [Serializable]
    public class EMovimentacaoConta
    {
        public EMovimentacaoConta()
        {
            Associado = new EAssociado();
        }

        public DateTime DataHoraMovimentacao { get; set; }
        public decimal Valortotal { get; set; }
        public int IdAssociado { get; set; }
        public EAssociado Associado { get; set; }
        public int IdMovimentacao { get; set; }
        public string ListaItens { get; set; }
    }
}
