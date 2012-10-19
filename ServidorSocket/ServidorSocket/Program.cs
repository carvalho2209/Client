using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;

namespace ServidorSocket
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declara um objeto que irá "escutar" a rede na porta especificada
            TcpListener servidor = new TcpListener(5555);

            //Inicializa o serviço do servidor
            servidor.Start();

            //Aguarda a conexao, e cria o objeto com a conexão do cliente
            //quando estabelecida
            Console.WriteLine("Aguardando conexão do cliente");
            Socket conexaoCliente = servidor.AcceptSocket();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Conexão estabelecida!");
            Console.ResetColor();


            //Cria um streaming de conexão com o cliente
            NetworkStream dadosConexao = new NetworkStream(conexaoCliente);
            
            //Cria o objeto para ler as informações enviadas pelo cliente
            BinaryReader entradaDados = new BinaryReader(dadosConexao);
            
            //Cria o objeto para escrever informações para o cliente
            BinaryWriter saidaDados = new BinaryWriter(dadosConexao);

            string strMensagem = string.Empty;

            do
            {
                //Recebe a mensagem do cliente
                strMensagem = entradaDados.ReadString();
                
                //Escreve na tela
                Console.WriteLine("Mensagem recebida do cliente: {0}", strMensagem);

                //Retorna mensagem para o cliente
                saidaDados.Write("Você digitou:" +  strMensagem);

            } while (strMensagem.ToUpper() != "FIM");

            //Para o servidor
            servidor.Stop();
            Console.WriteLine("Fim da execução");

        }
    }
}
