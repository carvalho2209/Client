using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace ClienteSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declara o objeto para a conexao com o servidor
            TcpClient cliente = new TcpClient();
            //Seta os parametros para  a conexao e a estabelece
            cliente.Connect("127.0.0.1", 5555);

            //Cria o streaming de conexao baseado na conexao com o servidor
            NetworkStream dadosConexao = cliente.GetStream();

            //Cria o objeto de entrada dos dados
            BinaryReader entradaDados = new BinaryReader(dadosConexao);
            
            //Cria o objeto para a saída dos dados
            BinaryWriter saidaDados = new BinaryWriter(dadosConexao);

            string strMensagem = string.Empty;
            do
            {
                Console.Write("Digite a mensagem:");
                strMensagem = Console.ReadLine();

                saidaDados.Write(strMensagem);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Msg recebida:{0}",entradaDados.ReadString());
                Console.ResetColor();

                Console.WriteLine("\nPressione qualquer tecla para continuar.");
                Console.ReadKey();

            } while (strMensagem.ToUpper() != "FIM");
            Console.WriteLine("Fim da conexão.");
        }
    }
}
