using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade
{
    [Serializable]
    public class EMensalidade
    {
        public EMensalidade()
        {
            Associado = new EAssociado();
        }

        public int Identficador_Mensalidade { get; set; }
        public int ID_Associado { get; set; }
        public string Referencia { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime ? DataPagamento { get; set; }
        public decimal ValorMensalidade { get; set; }
        public decimal  ? ValorPagamento { get; set; }
        public EAssociado Associado { get; set; }

    }
}
