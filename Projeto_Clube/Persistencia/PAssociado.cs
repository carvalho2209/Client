using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade;
using System.Data.SqlServerCe;

namespace Persistencia
{
    public class PAssociado
    {
        public EAssociado Incluir(EAssociado associado)
        {
            SqlCeConnection cnn = new SqlCeConnection();
            cnn.ConnectionString = Conexao.Caminho;

            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = cnn;

            #region inserção do associado
            cmd.CommandText = @"INSERT INTO Associado 
                               (Nome, Endereco, Telefone, Identificador_Tipo_Associado)
                                VALUES ( @Nome, @Endereco, @Telefone, @Id)";

            cmd.Parameters.Add("@Nome", associado.nome);
            cmd.Parameters.Add("@Endereco", associado.endereco);
            cmd.Parameters.Add("@Telefone", associado.telefone);
            cmd.Parameters.Add("@Id", associado.tipoAssociado.identificador);

            //Executa o comando setado - INSERT
            cnn.Open();
            cmd.ExecuteNonQuery();
            #endregion inserção do associado

            //Gera o comando sql para recuperar o último id 
            //gerado pelo insert acima
            cmd.CommandText = "SELECT @@Identity as id";
            
            //Executa o command retornando um DataReader
            SqlCeDataReader rdr =  cmd.ExecuteReader();

            //Lê o datareader gerado
            rdr.Read();
            //Seta para a entidade, o valor retornado pelo dataReader
            associado.identificador = int.Parse(rdr["id"].ToString());
            
            //Fecha a conexão
            cnn.Close();

            return associado;
        }

        public bool Alterar(EAssociado associado)
        {
            SqlCeConnection cnn = new SqlCeConnection();
            cnn.ConnectionString = Conexao.Caminho;

            SqlCeCommand cmd = new SqlCeCommand();
            cmd.Connection = cnn;

            #region alteracao do associado
            cmd.CommandText = @"UPDATE Associado SET 
                               Nome = @Nome, 
                               Endereco = @Endereco, 
                               Telefone = @Telefone, 
                               Identificador_Tipo_Associado = @Identificador_Tipo_Associado
                               WHERE Identificador = @Id ";

            cmd.Parameters.Add("@Nome", associado.nome);
            cmd.Parameters.Add("@Endereco", associado.endereco);
            cmd.Parameters.Add("@Telefone", associado.telefone);
            cmd.Parameters.Add("@Identificador_Tipo_Associado", associado.tipoAssociado.identificador);
            cmd.Parameters.Add("@Id", associado.identificador);

            //Executa o comando setado - UPDATE
            cnn.Open();
            cmd.ExecuteNonQuery();
            #endregion alteracao do associado
            
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

            #region exclusao do associado
            cmd.CommandText = @"DELETE FROM Associado
                               WHERE Identificador = @Id ";

            cmd.Parameters.Add("@Id", identificador);

            //Executa o comando setado - DELETE
            cnn.Open();
            cmd.ExecuteNonQuery();
            #endregion exclusao do associado

            //Fecha a conexão
            cnn.Close();

            return true;
        }

        public EAssociado Consultar(int identificador)
        {
            #region declaração de variáveis
            SqlCeConnection cnn = new SqlCeConnection();
            SqlCeCommand cmd = new SqlCeCommand();

            cnn.ConnectionString = Conexao.Caminho;
            cmd.Connection = cnn;
            #endregion declaração de variáveis

            cmd.CommandText = "SELECT * FROM Associado WHERE identificador = @identificador";
            cmd.Parameters.Add("@identificador", identificador);

            cnn.Open();
            SqlCeDataReader rdr = cmd.ExecuteReader();
            EAssociado _associado = new EAssociado();

            if (rdr.Read())
            {
                _associado.identificador = int.Parse(rdr["identificador"].ToString());
                _associado.nome = rdr["Nome"].ToString();
                _associado.endereco = rdr["Endereco"].ToString();
                _associado.telefone = rdr["Telefone"].ToString();
                _associado.tipoAssociado.identificador  = int.Parse(rdr["identificador_tipo_associado"].ToString());

                //Preenche o objeto TipoAssociado da classe Associado em questão
                PTipoAssociado pTipoAssociado = new PTipoAssociado();
                _associado.tipoAssociado = pTipoAssociado.Consultar(_associado.tipoAssociado.identificador);

            }
            cnn.Close();
            return _associado;
        }

        public List<EAssociado> Listar(EAssociado associado)
        {
            #region declaração de variáveis
            SqlCeConnection cnn = new SqlCeConnection();
            SqlCeCommand cmd = new SqlCeCommand();

            cnn.ConnectionString = Conexao.Caminho;
            cmd.Connection = cnn;
            #endregion declaração de variáveis

            cmd.CommandText = "SELECT * FROM Associado";

            if (associado.nome != null)
            {
                cmd.CommandText += " WHERE Nome Like @Nome";
                cmd.Parameters.Add("@Nome", "%" + associado.nome + "%");
            }
            cmd.CommandText += " ORDER BY Nome";

            cnn.Open();
            SqlCeDataReader rdr = cmd.ExecuteReader();

            List<EAssociado> lstRetorno = new List<EAssociado>();
            PTipoAssociado pTipoAssociado = new PTipoAssociado();

            while (rdr.Read())
            {
                EAssociado _associado = new EAssociado();
                _associado.identificador            = int.Parse(rdr["identificador"].ToString());
                _associado.nome                     = rdr["Nome"].ToString();
                _associado.endereco                 = rdr["Endereco"].ToString();
                _associado.telefone                 = rdr["Telefone"].ToString();
                _associado.tipoAssociado.identificador 
                    = int.Parse(rdr["identificador_tipo_associado"].ToString());

                //Preenche o objeto TipoAssociado da classe Associado em questão
                _associado.tipoAssociado = pTipoAssociado.Consultar(_associado.tipoAssociado.identificador);

                lstRetorno.Add(_associado);            
            }
            cnn.Close();
            return lstRetorno;
        }
    }
}
