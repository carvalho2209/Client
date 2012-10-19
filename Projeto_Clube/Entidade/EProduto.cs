using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade
{
    [Serializable]
    public class EProduto
    {
        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public decimal ValorUnitario { get; set; }
        public int QtdTotal { get; set; }
    }
}
