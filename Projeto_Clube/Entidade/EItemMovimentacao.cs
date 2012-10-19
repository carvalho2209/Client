using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade
{
    [Serializable]
    class EItemMovimentacao
    {
        public EItemMovimentacao()
        {
            MovimentacaoConta = new EMovimentacaoConta();
            Produto = new EProduto();
        }

        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public int IdMovimentacao { get; set; }
        public int IdProduto { get; set; }
        public EProduto Produto { get; set; }
        public EMovimentacaoConta MovimentacaoConta { get; set; }
        public string EMovimetacao { get; set; }
    }
}
