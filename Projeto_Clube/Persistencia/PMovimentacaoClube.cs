using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade;
using System.Data.SqlServerCe;

namespace Persistencia
{
    public class PMovimentacaoClube
    {
        public EMovimentacaoClube Incluir(EMovimentacaoClube movimentacaoClube)
        {
            SqlCeConnection cnn = new SqlCeConnection();
            cnn.ConnectionString = Conexao.Caminho;

            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = cnn;

            #region inserção do movimentacaoClube
            cmd.CommandText = @"INSERT INTO Movimentacao_Clube 
                               (IDAssociado, DataHoraEntrada)
                                VALUES ( @ID_Associado, @DataHoraEntrada)";

            cmd.Parameters.Add("@ID_Associado", movimentacaoClube.ID_Associado);
            cmd.Parameters.Add("@DataHoraEntrada", movimentacaoClube.DataHoraEntrada);

            //Executa o comando setado - INSERT
            cnn.Open();
            cmd.ExecuteNonQuery();
            #endregion inserção do movimentacaoClube

            //Gera o comando sql para recuperar o último id 
            //gerado pelo insert acima
            cmd.CommandText = "SELECT @@Identity as id";
            
            //Executa o command retornando um DataReader
            SqlCeDataReader rdr =  cmd.ExecuteReader();

            //Lê o datareader gerado
            rdr.Read();
            //Seta para a entidade, o valor retornado pelo dataReader
            movimentacaoClube.ID_Associado = int.Parse(rdr["id"].ToString());
            movimentacaoClube.Associado = new PAssociado().Consultar(movimentacaoClube.ID_Associado);
            
            //Fecha a conexão
            cnn.Close();

            return movimentacaoClube;
        }

        public bool Alterar(EMovimentacaoClube movimentacaoClube)
        {
            SqlCeConnection cnn = new SqlCeConnection();
            cnn.ConnectionString = Conexao.Caminho;

            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = cnn;

            #region alteracao do movimentacaoClube
            cmd.CommandText = @"UPDATE Movimentacao_Clube SET 
                               DataHoraSaida            = @DataHoraSaida 
                               WHERE ID_Movimentacao    = @Id ";

            cmd.Parameters.Add("@ID", movimentacaoClube.Identficador_Movimentacao);
            cmd.Parameters.Add("@DataHoraSaida", movimentacaoClube.DataHoraSaida);

            //Executa o comando setado - UPDATE
            cnn.Open();
            cmd.ExecuteNonQuery();
            #endregion alteracao do movimentacaoClube
            
            //Fecha a conexão
            cnn.Close();

            return true;
        }


        public EMovimentacaoClube ConsultarEntrada(int idAssociado)
        {
            #region declaração de variáveis
            SqlCeConnection cnn = new SqlCeConnection();
            SqlCeCommand cmd = new SqlCeCommand();

            cnn.ConnectionString = Conexao.Caminho;
            cmd.Connection = cnn;
            #endregion declaração de variáveis

            cmd.CommandText = "SELECT * FROM Movimentacao_Clube WHERE IDAssociado = @identificador and DataHoraSaida is null";
            cmd.Parameters.Add("@identificador", idAssociado);

            cnn.Open();
            SqlCeDataReader rdr = cmd.ExecuteReader();
            EMovimentacaoClube _movimentacaoClube = new EMovimentacaoClube();

            if (rdr.Read())
            {
                PreencherEntidade(rdr, _movimentacaoClube);

            }
            cnn.Close();
            return _movimentacaoClube;
        }



        public List<EMovimentacaoClube> Listar(int idAssociado)
        {
            #region declaração de variáveis
            SqlCeConnection cnn = new SqlCeConnection();
            SqlCeCommand cmd = new SqlCeCommand();

            cnn.ConnectionString = Conexao.Caminho;
            cmd.Connection = cnn;
            #endregion declaração de variáveis

            cmd.CommandText = "SELECT * FROM Movimentacao_Clube";
            cmd.CommandText += " WHERE ID_Associado = @IDAssociado";
            cmd.CommandText += " ORDER BY Referencia";
            cmd.Parameters.Add("@IDAssociado", idAssociado);

            cnn.Open();
            SqlCeDataReader rdr = cmd.ExecuteReader();

            List<EMovimentacaoClube> lstRetorno = new List<EMovimentacaoClube>();
            PAssociado pAssociado = new PAssociado();

            while (rdr.Read())
            {
                EMovimentacaoClube _movimentacaoClube = new EMovimentacaoClube();
                PreencherEntidade(rdr, _movimentacaoClube);
                lstRetorno.Add(_movimentacaoClube);            
            }
            cnn.Close();
            return lstRetorno;
        }

        private static void PreencherEntidade(SqlCeDataReader rdr, EMovimentacaoClube _movimentacaoClube)
        {
            _movimentacaoClube.Identficador_Movimentacao = int.Parse(rdr["ID_Movimentacao"].ToString());
            _movimentacaoClube.ID_Associado = int.Parse(rdr["IDAssociado"].ToString());
            _movimentacaoClube.DataHoraEntrada = DateTime.Parse(rdr["DataHoraEntrada"].ToString());
            if (!string.IsNullOrEmpty(rdr["DataHoraSaida"].ToString()))
                _movimentacaoClube.DataHoraSaida = DateTime.Parse(rdr["DataHoraSaida"].ToString());

            //Preenche o objeto TipoMovimentacaoClube da classe MovimentacaoClube em questão
            PAssociado pAssociado = new PAssociado();
            _movimentacaoClube.Associado = pAssociado.Consultar(_movimentacaoClube.ID_Associado);
        }
    }
}
