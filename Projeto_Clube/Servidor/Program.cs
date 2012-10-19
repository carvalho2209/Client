using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using Negocio;
using System.Threading;

namespace Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cria um objeto TcpListener para "escutar" conexões na porta 5000 
            TcpListener servidor = new TcpListener(5555);
            //Inicia o servidor
            servidor.Start();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Servidor aguardando conexões na porta 5555");
            Console.ResetColor();

            while (true)
            {
                Socket conexao = servidor.AcceptSocket(); //Aceita uma conexão
                Console.WriteLine("Nova conexão aceita!");
                ConexaoCliente c = new ConexaoCliente(conexao); //Cria um objeto ConexaoCliente para a conexão aceita
                Thread cc = new Thread(new ThreadStart(c.processarConexao)); //Processa os dados da conexão como uma Thread independente
                cc.Start(); //Inicia a Thread criada
            }
        }
    }

    class ConexaoCliente
    {
        //Objetos de fluxo de dados necessários para a conexão
        NetworkStream fluxos;
        BinaryReader entrada;
        BinaryWriter saida;
        Socket cliente;

        //Quando um objeto ConexaoCliente é criado, o socket da conexão deve ser passado como referência
        public ConexaoCliente(Socket s)
        {
            //Inicia os objetos
            this.cliente = s;
            fluxos = new NetworkStream(this.cliente);
            entrada = new BinaryReader(fluxos);
            saida = new BinaryWriter(fluxos);
        }

        public void processarConexao()
        {
            try
            {
                if (entrada != null)
                {
                    String msg = entrada.ReadString(); //Lê a mensagem do cliente
                    while (msg != "fim")
                    {
                        Console.WriteLine("Mensagem recebida: " + msg);

                        //Faz o registro da passagem
                        msg = new NMovimentacaoClube().RegistrarPassagem(int.Parse(msg));


                        saida.Write("RESPOSTA: " + msg.ToUpper()); //"Processa" a resposta (só converte para maiúscula)
                        Console.WriteLine("Mensagem retornada: " + msg);
                        
                        msg = entrada.ReadString(); //Lê a próxima mensagem

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                //Finaliza os componentes no final da conexão
                entrada.Close();
                saida.Close();
                fluxos.Close();
                cliente.Close();
            }
            Console.WriteLine("Conexão finalizada!");

        }



    }
       
}
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            //Declara um objeto que irá "escutar" a rede na porta especificada
//            TcpListener servidor = new TcpListener(5555);

//            //Inicializa o serviço do servidor
//            servidor.Start();

//            //Aguarda a conexao, e cria o objeto com a conexão do cliente
//            //quando estabelecida
//            Console.WriteLine("Aguardando conexão do cliente");
//            Socket conexaoCliente = servidor.AcceptSocket();

//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine("Conexão estabelecida!");
//            Console.ResetColor();


//            //Cria um streaming de conexão com o cliente
//            NetworkStream dadosConexao = new NetworkStream(conexaoCliente);

//            //Cria o objeto para ler as informações enviadas pelo cliente
//            BinaryReader entradaDados = new BinaryReader(dadosConexao);

//            //Cria o objeto para escrever informações para o cliente
//            BinaryWriter saidaDados = new BinaryWriter(dadosConexao);
//            while (true)
//            {
//                Teste t = new Teste();
//                Thread cc = new Thread(new ThreadStart(t.VerificarPassagem(entradaDados, saidaDados)));
//                cc.Start(); //Inicia a Thread criada
//            }

//            //Para o servidor
//            servidor.Stop();
//            Console.WriteLine("Fim da execução");

//        }
       
//    }

//    class Teste
//    {
//        
//    }
//}
