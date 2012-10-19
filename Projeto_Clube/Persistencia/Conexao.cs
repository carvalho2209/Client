using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Persistencia
{
    public static class Conexao
    {
        public static string Caminho { 
            get{

                string strCaminho = string.Empty;

                //Setando o caminho do banco dentro do método construtor da classe
                strCaminho = (@"Data Source='" +
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BancoDeDados")
                    + @"\Clube.sdf';Persist Security Info=False;")
                    .Replace("Servico", "Persistencia");

                strCaminho = @"Data Source='C:\Users\Alexandre\Documents\Visual Studio 2012\Projects\DSCS-2012-2-Clube\Projeto_Clube\Persistencia\BancoDeDados\Clube.sdf';Persist Security Info=False;";

                return strCaminho;


               }
        }
    }
}
