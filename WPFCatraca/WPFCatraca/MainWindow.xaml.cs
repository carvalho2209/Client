using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace WPFCatraca
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Declara o objeto para a conexao com o servidor
        TcpClient cliente = new TcpClient();

        public MainWindow()
        {
            InitializeComponent();

            //Seta os parametros para  a conexao e a estabelece
            cliente.Connect("127.0.0.1", 5555);
        }

        private void btnRegistrarPassagem_Click(object sender, RoutedEventArgs e)
        {
            if (!NumeroValido(txtIdentificador.Text))
            {
                MessageBox.Show("Identificador inválido. Digite Somente números!");
            }
            else
            {

                Teste t = new Teste(lblResultado, txtIdentificador);
                Thread tr = new Thread(new ThreadStart(t.Limpar));

                //Cria o streaming de conexao baseado na conexao com o servidor
                NetworkStream dadosConexao = cliente.GetStream();

                //Cria o objeto de entrada dos dados
                BinaryReader entradaDados = new BinaryReader(dadosConexao);
                //Cria o objeto para a saída dos dados
                BinaryWriter saidaDados = new BinaryWriter(dadosConexao);

                //Manda a mensagem
                saidaDados.Write(txtIdentificador.Text);

                if (entradaDados != null)
                {
                    string resultado = entradaDados.ReadString();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Msg recebida:{0}", resultado);
                    Console.ResetColor();

                    lblResultado.Text = resultado;
                }
                
                Console.WriteLine("Fim da conexão.");



            }

        }

        static bool NumeroValido(string numberString)
        {
            int resposta = 0;
            return System.Int32.TryParse(numberString, out resposta);
        }

        private void txtIdentificador_GotFocus(object sender, RoutedEventArgs e)
        {
            txtIdentificador.Text = "";
            lblResultado.Text = "";
        }


       

    }

    class Teste
    {
        TextBlock resultado;
        TextBox identificador;
        public Teste(TextBlock p1, TextBox p2)
        {
            resultado = p1;
            identificador = p2;
        }

        public void Limpar()
        {
            Thread.Sleep(2000);
            resultado.Text = "";
            identificador.Text = "";
        }
    }
}
