using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConsultaDAL
    {
        public DataTable CONSULTA(string pParam, string pStrConexao)
        {
            SqlConnection cn = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable result = new DataTable();
            try
            {
                cn.ConnectionString = pStrConexao;
                da.SelectCommand = new SqlCommand();

                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.CommandText = "CONSULTA_CONTATO";
                da.SelectCommand.Connection = cn;
                SqlParameter pFiltro;
                pFiltro = da.SelectCommand.Parameters.Add("@PARAM", SqlDbType.VarChar, 20);
                pFiltro.Value = pParam;

                da.Fill(result);
                return result;

            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Erro:" + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
