using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade;
using Persistencia;

namespace TesteConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            EAssociado associado = new EAssociado();

            Console.Write("Digite Nome: ");
            associado.nome = Console.ReadLine();

            Console.Write("Digite Endereço: ");
            associado.endereco = Console.ReadLine();

            Console.Write("Digite Telefone: ");
            associado.telefone = Console.ReadLine();

            Console.Write("Digite Tipo do Associado: ");
            associado.tipoAssociado.identificador = int.Parse(Console.ReadLine());


            PAssociado pAssociado = new PAssociado();
            associado = pAssociado.Incluir(associado);

            Console.WriteLine();
            Console.WriteLine("Associado incluído com o ID:{0}"
                , associado.identificador.ToString());


            EAssociado _associado = new EAssociado();
            List<EAssociado> lstRetorno = pAssociado.Listar(_associado);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");

            foreach (EAssociado objAssociado in lstRetorno)
            {
                Console.WriteLine("Identificador...:{0}", objAssociado.identificador);
                Console.WriteLine("Nome............:{0}", objAssociado.nome);
                Console.WriteLine("Telefone........:{0}", objAssociado.telefone);
                Console.WriteLine("Endereço........:{0}", objAssociado.endereco);
                Console.WriteLine("Tipo Associado..:{0}", objAssociado.tipoAssociado.identificador);
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine();

            }
            Console.ReadKey();

        }
    }
}
