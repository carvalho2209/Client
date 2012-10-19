using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade;
using System.Data.SqlServerCe;

namespace Persistencia
{
    public class PMensalidade
    {
        public EMensalidade Incluir(EMensalidade mensalidade)
        {
            SqlCeConnection cnn = new SqlCeConnection();
            cnn.ConnectionString = Conexao.Caminho;

            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = cnn;

            #region inserção do mensalidade
            cmd.CommandText = @"INSERT INTO Mensalidade 
                               (ID_Associado, Referencia, DataVencimento, DataPagamento, ValorMensalidade, ValorPagamento)
                                VALUES ( @ID_Associado, @Referencia, @DataVencimento, @DataPagamento, @ValorMensalidade, @ValorPagamento)";

            cmd.Parameters.Add("@ID_Associado", mensalidade.ID_Associado);
            cmd.Parameters.Add("@Referencia", mensalidade.Referencia);
            cmd.Parameters.Add("@DataVencimento", mensalidade.DataVencimento);
            cmd.Parameters.Add("@ValorMensalidade", mensalidade.ValorMensalidade);
            if (!mensalidade.DataPagamento.HasValue)
            {
                cmd.Parameters.Add("@DataPagamento", mensalidade.DataPagamento);
                cmd.Parameters.Add("@ValorPagamento", mensalidade.ValorPagamento);
            }
            else
            {
                cmd.Parameters.Add("@DataPagamento",DBNull.Value);
                cmd.Parameters.Add("@ValorPagamento", DBNull.Value);
            
            }

            //Executa o comando setado - INSERT
            cnn.Open();
            cmd.ExecuteNonQuery();
            #endregion inserção do mensalidade

            //Gera o comando sql para recuperar o último id 
            //gerado pelo insert acima
            cmd.CommandText = "SELECT @@Identity as id";
            
            //Executa o command retornando um DataReader
            SqlCeDataReader rdr =  cmd.ExecuteReader();

            //Lê o datareader gerado
            rdr.Read();
            //Seta para a entidade, o valor retornado pelo dataReader
            mensalidade.Identficador_Mensalidade = int.Parse(rdr["id"].ToString());
            mensalidade.Associado = new PAssociado().Consultar(mensalidade.ID_Associado);
            
            //Fecha a conexão
            cnn.Close();

            return mensalidade;
        }

        public bool Alterar(EMensalidade mensalidade)
        {
            SqlCeConnection cnn = new SqlCeConnection();
            cnn.ConnectionString = Conexao.Caminho;

            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = cnn;

            #region alteracao do mensalidade
            cmd.CommandText = @"UPDATE Mensalidade SET 
                               Referencia           = @Referencia , 
                               DataVencimento       = @DataVencimento, 
                               DataPagamento        = @DataPagamento, 
                               ValorMensalidade     = @ValorMensalidade, 
                               ValorPagamento       = @ValorPagamento
                               WHERE Identificador  = @Id ";

            cmd.Parameters.Add("@ID", mensalidade.Identficador_Mensalidade);
            cmd.Parameters.Add("@Referencia", mensalidade.Referencia);
            cmd.Parameters.Add("@DataVencimento", mensalidade.DataVencimento);
            cmd.Parameters.Add("@DataPagamento", mensalidade.DataPagamento);
            cmd.Parameters.Add("@ValorMensalidade", mensalidade.ValorMensalidade);
            cmd.Parameters.Add("@ValorPagamento", mensalidade.ValorPagamento);

            //Executa o comando setado - UPDATE
            cnn.Open();
            cmd.ExecuteNonQuery();
            #endregion alteracao do mensalidade
            
            //Fecha a conexão
            cnn.Close();

            return true;
        }

        public bool Excluir(int identificador)
        {
            SqlCeConnection cnn = new SqlCeConnection();
            cnn.ConnectionString = Conexao.Caminho;

            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = cnn;

            #region exclusao do mensalidade
            cmd.CommandText = @"DELETE FROM Mensalidade
                               WHERE Identificador = @Id ";

            cmd.Parameters.Add("@Id", identificador);

            //Executa o comando setado - DELETE
            cnn.Open();
            cmd.ExecuteNonQuery();
            #endregion exclusao do mensalidade

            //Fecha a conexão
            cnn.Close();

            return true;
        }

        public EMensalidade Consultar(int identificador)
        {
            #region declaração de variáveis
            SqlCeConnection cnn = new SqlCeConnection();
            SqlCeCommand cmd = new SqlCeCommand();

            cnn.ConnectionString = Conexao.Caminho;
            cmd.Connection = cnn;
            #endregion declaração de variáveis

            cmd.CommandText = "SELECT * FROM Mensalidade WHERE identificador = @identificador";
            cmd.Parameters.Add("@identificador", identificador);

            cnn.Open();
            SqlCeDataReader rdr = cmd.ExecuteReader();
            EMensalidade _mensalidade = new EMensalidade();

            if (rdr.Read())
            {
                _mensalidade.Identficador_Mensalidade   = int.Parse(rdr["identificador"].ToString());
                _mensalidade.ID_Associado               = int.Parse(rdr["id_associado"].ToString());
                _mensalidade.Referencia                 = rdr["Referencia"].ToString();
                _mensalidade.ValorMensalidade           = decimal.Parse(rdr["ValorMensalidade"].ToString());
                _mensalidade.ValorPagamento             = rdr["ValorPagamento"] == null ? 0 : decimal.Parse(rdr["ValorPagamento"].ToString());
                _mensalidade.DataVencimento             = DateTime.Parse(rdr["DataVencimento"].ToString());
                if(rdr["DataPagamento"] != null)
                    _mensalidade.DataPagamento              =  DateTime.Parse(rdr["DataPagamento"].ToString());

                //Preenche o objeto TipoMensalidade da classe Mensalidade em questão
                PAssociado pAssociado = new PAssociado();
                _mensalidade.Associado = pAssociado.Consultar(_mensalidade.ID_Associado);

            }
            cnn.Close();
            return _mensalidade;
        }

        public List<EMensalidade> Listar(int idAssociado)
        {
            #region declaração de variáveis
            SqlCeConnection cnn = new SqlCeConnection();
            SqlCeCommand cmd = new SqlCeCommand();

            cnn.ConnectionString = Conexao.Caminho;
            cmd.Connection = cnn;
            #endregion declaração de variáveis

            cmd.CommandText = "SELECT * FROM Mensalidade";
            cmd.CommandText += " WHERE ID_Associado = @IDAssociado";
            cmd.CommandText += " ORDER BY Referencia";
            cmd.Parameters.Add("@IDAssociado", idAssociado);

            cnn.Open();
            SqlCeDataReader rdr = cmd.ExecuteReader();

            List<EMensalidade> lstRetorno = new List<EMensalidade>();
            PAssociado pAssociado = new PAssociado();

            while (rdr.Read())
            {
                EMensalidade _mensalidade = new EMensalidade();

                _mensalidade.Identficador_Mensalidade = int.Parse(rdr["identificador"].ToString());
                _mensalidade.ID_Associado = int.Parse(rdr["id_associado"].ToString());
                _mensalidade.Referencia = rdr["Referencia"].ToString();
                _mensalidade.ValorMensalidade = decimal.Parse(rdr["ValorMensalidade"].ToString());
                _mensalidade.DataVencimento = DateTime.Parse(rdr["DataVencimento"].ToString());

                _mensalidade.DataPagamento = rdr["DataPagamento"].ToString() == "" ? new DateTime() : DateTime.Parse(rdr["DataPagamento"].ToString());
                _mensalidade.ValorPagamento = rdr["ValorPagamento"].ToString() == "" ? 0 : decimal.Parse(rdr["ValorPagamento"].ToString());
                
                //if (rdr["DataPagamento"].ToString() != "")
                //    _mensalidade.DataPagamento = DateTime.Parse(rdr["DataPagamento"].ToString());

                //Preenche o objeto TipoMensalidade da classe Mensalidade em questão
                _mensalidade.Associado = pAssociado.Consultar(_mensalidade.ID_Associado);

                lstRetorno.Add(_mensalidade);            
            }
            cnn.Close();
            return lstRetorno;
        }

        public bool VerificarMensalidadeEmAberto(int idAssociado)
        {
            #region declaração de variáveis
            SqlCeConnection cnn = new SqlCeConnection();
            SqlCeCommand cmd = new SqlCeCommand();

            cnn.ConnectionString = Conexao.Caminho;
            cmd.Connection = cnn;
            #endregion declaração de variáveis

            cmd.CommandText = "SELECT * FROM Mensalidade WHERE DataPagamento is null and DataVencimento <= GetDate() and ID_Associado = @identificador";
            cmd.Parameters.Add("@identificador", idAssociado);

            cnn.Open();
            SqlCeDataReader rdr = cmd.ExecuteReader();
            EMensalidade _mensalidade = new EMensalidade();

            bool retorno = false;
            if (rdr.Read())
                return true;

            cnn.Close();
            return retorno;
        }
    }
}
