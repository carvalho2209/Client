using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using Entidade;

namespace Persistencia
{
    public class PMovimentacaoConta
    {
        public EMovimentacaoConta Incluir(EMovimentacaoConta movimentacaoConta)
        {
            SqlCeConnection cnn = new SqlCeConnection();
            cnn.ConnectionString = Conexao.Caminho;

            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = cnn;

            #region inserção do TipoMovimentacaoConta
            cmd.CommandText = @"INSERT INTO MovimentacaoConta 
                               (dataHoraMovimentacao, valortotal, Id_Associado, Id_Movimentacao, ListaItens)
                                VALUES (@dataHoraMovimentacao, @valorTotal, @Id_Associado, @Id_Movimentacao, @ListaItens)";

            cmd.Parameters.Add("@dataHoraMovimentacao", movimentacaoConta.DataHoraMovimentacao);
            cmd.Parameters.Add("@valorTotal", movimentacaoConta.Valortotal);
            cmd.Parameters.Add("@Id_Associado", movimentacaoConta.IdAssociado);
            cmd.Parameters.Add("@Id_Movimentacao", movimentacaoConta.IdMovimentacao);
            cmd.Parameters.Add("@ListaItens", movimentacaoConta.ListaItens);

            //Executa o comando setado - INSERT
            cnn.Open();
            cmd.ExecuteNonQuery();
            #endregion inserção do associado

            //Gera o comando sql para recuperar o último id 
            //gerado pelo insert acima
            cmd.CommandText = "SELECT @@Identity as id";

            //Executa o command retornando um DataReader
            SqlCeDataReader rdr = cmd.ExecuteReader();

            //Lê o datareader gerado
            rdr.Read();
            //Seta para a entidade, o valor retornado pelo dataReader
            movimentacaoConta.IdMovimentacao = int.Parse((rdr["Id_Movimentacao"].ToString()));

            //Fecha a conexão
            cnn.Close();

            return movimentacaoConta;
        }

        public bool Alterar(EMovimentacaoConta movementacaoConta)
        {
            SqlCeConnection cnn = new SqlCeConnection();
            cnn.ConnectionString = Conexao.Caminho;

            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = cnn;

            #region alteracao do associado
            cmd.CommandText = @"UPDATE MovimentacaoConta SET 
                               dataHoraMovimentacao = @dataHoraMovimentacao, 
                               valortotal = @valortotal,
                               Id_Associado = @Id_Associado,
                               Id_Movimentacao = @Id_Movimentacao
                               ListaItens = @ListaItens
                               WHERE Id_Movimentacao = @Id ";

            cmd.Parameters.Add("@Nome", movementacaoConta.DataHoraMovimentacao);
            cmd.Parameters.Add("@valorTotal", movementacaoConta.Valortotal);
            cmd.Parameters.Add("@IdMovimentacao", movementacaoConta.IdAssociado);
            cmd.Parameters.Add("@IdMovimentacao", movementacaoConta.IdMovimentacao);
            cmd.Parameters.Add("@Listaitens", movementacaoConta.ListaItens);

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
            cmd.CommandText = @"DELETE FROM MovemtacaoConta
                               WHERE IdMovimentacao = @Id ";

            cmd.Parameters.Add("@Id", id);

            //Executa o comando setado - DELETE
            cnn.Open();
            cmd.ExecuteNonQuery();
            #endregion exclusao do associado

            //Fecha a conexão
            cnn.Close();

            return true;
        }
        public EMovimentacaoConta Consultar(int id)
        {
            #region declaração de variáveis
            SqlCeConnection cnn = new SqlCeConnection();
            SqlCeCommand cmd = new SqlCeCommand();

            cnn.ConnectionString = Conexao.Caminho;
            cmd.Connection = cnn;
            #endregion declaração de variáveis

            cmd.CommandText = "SELECT * FROM MovimentacaoConta WHERE IdMovimentacaoConta = @id";
            cmd.Parameters.Add("@id", id);

            cnn.Open();
            SqlCeDataReader rdr = cmd.ExecuteReader();
            EMovimentacaoConta _eMovimentacaoConta = new EMovimentacaoConta();

            if (rdr.Read())
            {
                _eMovimentacaoConta.DataHoraMovimentacao = DateTime.Parse(rdr["DataHoraMovimentacaoConta"].ToString());
                _eMovimentacaoConta.Valortotal = decimal.Parse(rdr["ValorTotal"].ToString());
                _eMovimentacaoConta.IdAssociado = int.Parse(rdr["IdAssociado"].ToString());
                _eMovimentacaoConta.IdAssociado = int.Parse(rdr["IdMovimentacaoConta"].ToString());
                _eMovimentacaoConta.ListaItens = (rdr["ListaItens"].ToString());

                //Preenche o objeto TipoAssociado da classe Associado em questão
                PAssociado pAssociado = new PAssociado();
                _eMovimentacaoConta.Associado = pAssociado.Consultar(_eMovimentacaoConta.Associado.identificador);

            }
            cnn.Close();
            return _eMovimentacaoConta;
        }
         public List<EMovimentacaoConta> Listar(EMovimentacaoConta movimentacaoConta)
        {
            #region declaração de variáveis
            SqlCeConnection cnn = new SqlCeConnection();
            SqlCeCommand cmd = new SqlCeCommand();

            cnn.ConnectionString = Conexao.Caminho;
            cmd.Connection = cnn;
            #endregion declaração de variáveis

            cmd.CommandText = "SELECT * FROM MovimentacaoConta";

            if (movimentacaoConta.Associado != null)
            {
                cmd.CommandText += " WHERE Nome Like @Nome";
                cmd.Parameters.Add("@Nome", "%" + movimentacaoConta.Associado + "%");
            }
            cmd.CommandText += " ORDER BY Nome";

            cnn.Open();
            SqlCeDataReader rdr = cmd.ExecuteReader();

            List<EMovimentacaoConta> lstRetorno = new List<EMovimentacaoConta>();
            PMovimentacaoConta pMovimentacaoConta = new PMovimentacaoConta();
            

            while (rdr.Read())
            {
                EMovimentacaoConta _eMovimentacaoConta = new EMovimentacaoConta();
                _eMovimentacaoConta.DataHoraMovimentacao = DateTime.Parse(rdr["DataHoraMovimentacaoConta"].ToString());
                _eMovimentacaoConta.Valortotal = decimal.Parse(rdr["ValorTotal"].ToString());
                _eMovimentacaoConta.IdAssociado = int.Parse(rdr["IdAssociado"].ToString());
                _eMovimentacaoConta.IdAssociado = int.Parse(rdr["IdMovimentacaoConta"].ToString());
                _eMovimentacaoConta.ListaItens = (rdr["ListaItens"].ToString());
                
                //Preenche o objeto TipoAssociado da classe Associado em questão
                PAssociado pAssociado = new PAssociado();
                _eMovimentacaoConta.Associado = pAssociado.Consultar(_eMovimentacaoConta.Associado.identificador);

                lstRetorno.Add(_eMovimentacaoConta);            
            }
            cnn.Close();
            return lstRetorno;
        }
    }
 }


