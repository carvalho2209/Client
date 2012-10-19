using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade
{
    [Serializable]
    public class ETipoAssociado
    {
        public int identificador { get; set; }
        public string descricao { get; set; }
        public decimal valorMensalidade { get; set; }
    }
}
