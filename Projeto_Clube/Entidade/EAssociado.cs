using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade
{
    [Serializable]
    public class EAssociado
    {
        public EAssociado()
        {
            tipoAssociado = new ETipoAssociado();
        }
    
        public int identificador { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
        public ETipoAssociado tipoAssociado { get; set; }

    }
}
