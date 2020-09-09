using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TelefoneDAL : ConsultaDAL
    {
        public void Incluir(Telefone pTelefone, string pStrConexao, out int pId)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = pStrConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "INSERT_TELEFONE";

                SqlParameter pmail = new SqlParameter("@TELEFONE", SqlDbType.VarChar, 14);
                pmail.Value = pTelefone.Tel;
                cmd.Parameters.Add(pmail);

                SqlParameter pid = new SqlParameter("@ID_CONTATO", SqlDbType.Int);
                pid.Value = pTelefone.IdContato;
                cmd.Parameters.Add(pid);

                cn.Open();
                cmd.ExecuteNonQuery();

                pId = (Int32)cmd.Parameters["RET_VALUE"].Value;

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

        public void Alterar(Telefone pTelefone, string pStrConexao, out int pId)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = pStrConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UPDATE_TELEFONE";

                SqlParameter pnome = new SqlParameter("@TELEFONE", SqlDbType.VarChar, 14);
                pnome.Value = pTelefone.Tel;
                cmd.Parameters.Add(pnome);

                SqlParameter pid = new SqlParameter("@ID_TELEFONE", SqlDbType.Int);
                pid.Value = pTelefone.IdTel;
                cmd.Parameters.Add(pid);

                cn.Open();
                cmd.ExecuteNonQuery();

                pId = (Int32)cmd.Parameters["RET_VALUE"].Value;

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

        public void DELETE(int pIdTelefone, string pStrConexao, out int pId)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = pStrConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DELETE_TELEFONE";

                SqlParameter pid = new SqlParameter("@ID_TELEFONE", SqlDbType.Int);
                pid.Value = pIdTelefone;
                cmd.Parameters.Add(pid);

                cn.Open();
                cmd.ExecuteNonQuery();

                pId = (Int32)cmd.Parameters["RET_VALUE"].Value;

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
