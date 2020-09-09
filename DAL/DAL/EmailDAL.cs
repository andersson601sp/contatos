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
    public class EmailDAL : ConsultaDAL
    {
        public void Incluir(Email pEmail, string pStrConexao, out int pId)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = pStrConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "INSERT_EMAIL";

                SqlParameter pmail = new SqlParameter("@EMAIL", SqlDbType.VarChar, 200);
                pmail.Value = pEmail.Mail;
                cmd.Parameters.Add(pmail);

                SqlParameter pid = new SqlParameter("@ID_CONTATO", SqlDbType.Int);
                pid.Value = pEmail.IdContato;
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

        public void Alterar(Email pEmail, string pStrConexao, out int pId)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = pStrConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UPDATE_EMAIL";

                SqlParameter pnome = new SqlParameter("@EMAIL", SqlDbType.VarChar, 200);
                pnome.Value = pEmail.Mail;
                cmd.Parameters.Add(pnome);

                SqlParameter pid = new SqlParameter("@ID_EMAIL", SqlDbType.Int);
                pid.Value = pEmail.IdEmail;
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

        public void DELETE(int pIdEmail, string pStrConexao, out int pId)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = pStrConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DELETE_EMAIL";

                SqlParameter pid = new SqlParameter("@ID_EMAIL", SqlDbType.Int);
                pid.Value = pIdEmail;
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
