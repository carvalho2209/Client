using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade;
using System.Data.SqlServerCe;

namespace Persistencia
{
    public class PTipoAssociado
    {
        public ETipoAssociado Consultar(int identificador)
        {
            #region declaração de variáveis
            SqlCeConnection cnn = new SqlCeConnection();
            SqlCeCommand cmd = new SqlCeCommand();

            cnn.ConnectionString = Conexao.Caminho;
            cmd.Connection = cnn;
            #endregion declaração de variáveis

            cmd.CommandText = "SELECT * FROM TipoAssociado WHERE identificador = @identificador";
            cmd.Parameters.Add("@identificador", identificador);

            cnn.Open();
            SqlCeDataReader rdr = cmd.ExecuteReader();
            ETipoAssociado _TipoAssociado = new ETipoAssociado();

            if (rdr.Read())
            {
                _TipoAssociado.identificador = int.Parse(rdr["identificador"].ToString());
                _TipoAssociado.descricao = rdr["Descricao"].ToString();
            }
            cnn.Close();
            return _TipoAssociado;
        }

        public List<ETipoAssociado> Listar()
        {
            #region declaração de variáveis
            SqlCeConnection cnn = new SqlCeConnection();
            SqlCeCommand cmd = new SqlCeCommand();

            cnn.ConnectionString = Conexao.Caminho;
            cmd.Connection = cnn;
            #endregion declaração de variáveis

            cmd.CommandText = "SELECT * FROM TipoAssociado ORDER BY Descricao";

            cnn.Open();
            SqlCeDataReader rdr = cmd.ExecuteReader();

            List<ETipoAssociado> lstRetorno = new List<ETipoAssociado>();
            while (rdr.Read())
            {
                ETipoAssociado _TipoAssociado = new ETipoAssociado();
                _TipoAssociado.identificador = int.Parse(rdr["identificador"].ToString());
                _TipoAssociado.descricao = rdr["Descricao"].ToString();
                lstRetorno.Add(_TipoAssociado);
            }
            cnn.Close();
            return lstRetorno;
        }
    }
}
