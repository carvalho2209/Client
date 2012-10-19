using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using Entidade;

namespace Persistencia
{
    public class PProduto
    {
        public EProduto Incluir(EProduto produto)
        {
            SqlCeConnection cnn = new SqlCeConnection();
            cnn.ConnectionString = Conexao.Caminho;

            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = cnn;

            #region inserção do TipoMovimentacaoConta
            cmd.CommandText = @"INSERT INTO Produto 
                               (IdProduto, Descricao, Categoria, ValorUnitario, QtdTotal)
                                VALUES (@IdProduto, @Descricao, @Categoria, @ValorUnitario, @QtdTotal)";

            cmd.Parameters.Add("@IdProduto", produto.IdProduto);
            cmd.Parameters.Add("@Descricao", produto.Descricao);
            cmd.Parameters.Add("@Categoria", produto.Categoria);
            cmd.Parameters.Add("@ValorUnitario", produto.ValorUnitario);
            cmd.Parameters.Add("@QtdTotal", produto.QtdTotal);

            //Executa o comando setado - INSERT
            cnn.Open();
            cmd.ExecuteNonQuery();
            #endregion inserção do associado

            //Gera o comando sql para recuperar o último id 
            //gerado pelo insert acima
            cmd.CommandText = "SELECT @@Identity as IdProduto";

            //Executa o command retornando um DataReader
            SqlCeDataReader rdr = cmd.ExecuteReader();

            //Lê o datareader gerado
            rdr.Read();
            //Seta para a entidade, o valor retornado pelo dataReader
            produto.IdProduto = int.Parse(rdr["IdProduto"].ToString());

            //Fecha a conexão
            cnn.Close();

            return produto;
        }

        public bool Alterar(EProduto produto)
        {
            SqlCeConnection cnn = new SqlCeConnection();
            cnn.ConnectionString = Conexao.Caminho;

            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = cnn;

            #region alteracao do associado
            cmd.CommandText = @"UPDATE Produto SET 
                               IdProduto = @IdProduto, 
                               Descricao = @Descricao,
                               Categoria = @Categoria,
                               ValorUnitario = @ValorUnitario
                               QtdTotal = @QtdTotal
                               WHERE IdProduto = @Id ";

            cmd.Parameters.Add("@IdProduto", produto.IdProduto);
            cmd.Parameters.Add("@Descricao", produto.Descricao);
            cmd.Parameters.Add("@Categoria", produto.Categoria);
            cmd.Parameters.Add("@ValorUnitario", produto.ValorUnitario);
            cmd.Parameters.Add("@QtdTotal", produto.QtdTotal);

            //Executa o comando setado - UPDATE
            cnn.Open();
            cmd.ExecuteNonQuery();
            #endregion alteracao do associado

            //Fecha a conexão
            cnn.Close();

            return true;
        }
        public bool Excluir(int id)
        {
            SqlCeConnection cnn = new SqlCeConnection();
            cnn.ConnectionString = Conexao.Caminho;

            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = cnn;

            #region exclusao do associado
            cmd.CommandText = @"DELETE FROM Produto
                               WHERE IdProduto = @Id ";

            cmd.Parameters.Add("@Id", id);

            //Executa o comando setado - DELETE
            cnn.Open();
            cmd.ExecuteNonQuery();
            #endregion exclusao do associado

            //Fecha a conexão
            cnn.Close();

            return true;
        }
        public EProduto Consultar(int id)
        {
            #region declaração de variáveis
            SqlCeConnection cnn = new SqlCeConnection();
            SqlCeCommand cmd = new SqlCeCommand();

            cnn.ConnectionString = Conexao.Caminho;
            cmd.Connection = cnn;
            #endregion declaração de variáveis

            cmd.CommandText = "SELECT * FROM Produto WHERE IdProduto = @id";
            cmd.Parameters.Add("@id", id);

            cnn.Open();
            SqlCeDataReader rdr = cmd.ExecuteReader();
            EProduto _eProduto = new EProduto();

            if (rdr.Read())
            {
                _eProduto.IdProduto = int.Parse(rdr["IdProduto"].ToString());
                _eProduto.Descricao = (rdr["Descricao"].ToString());
                _eProduto.Categoria = (rdr["Categoria"].ToString());
                _eProduto.ValorUnitario = decimal.Parse(rdr["ValorUnitario"].ToString());
                _eProduto.QtdTotal = int.Parse(rdr["QtdTotal"].ToString());
            }
            cnn.Close();
            return _eProduto;
        }
        public List<EProduto> Listar(EProduto produto)
        {
            #region declaração de variáveis
            SqlCeConnection cnn = new SqlCeConnection();
            SqlCeCommand cmd = new SqlCeCommand();

            cnn.ConnectionString = Conexao.Caminho;
            cmd.Connection = cnn;
            #endregion declaração de variáveis

            cmd.CommandText = "SELECT * FROM Produto";

            if (produto.Categoria != null)
            {
                cmd.CommandText += " WHERE Categoria Like @Categoria";
                cmd.Parameters.Add("@Categoria", "%" + produto.Categoria + "%");
            }
            cmd.CommandText += " ORDER BY Categoria";

            cnn.Open();
            SqlCeDataReader rdr = cmd.ExecuteReader();

            List<EProduto> lstRetorno = new List<EProduto>();
            PProduto pProduto = new PProduto();


            while (rdr.Read())
            {
                EProduto _eProduto = new EProduto();
                
                _eProduto.IdProduto = int.Parse(rdr["IdProduto"].ToString());
                _eProduto.Descricao = (rdr["Descricao"].ToString());
                _eProduto.Categoria = (rdr["Categoria"].ToString());
                _eProduto.ValorUnitario = decimal.Parse(rdr["ValorUnitario"].ToString());
                _eProduto.QtdTotal = int.Parse(rdr["QtdTotal"].ToString());
                lstRetorno.Add(_eProduto);
            }
            cnn.Close();
            return lstRetorno;
        }
    }
}

