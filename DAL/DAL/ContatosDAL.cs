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
    public class ContatosDAL : ConsultaDAL
    {
        public void Incluir(Contatos pContatos, string pStrConexao, out int pId)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = pStrConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "INSERT_CONTATO";

                SqlParameter pnome = new SqlParameter("@NOME_CONTATO", SqlDbType.VarChar, 100);
                pnome.Value = pContatos.Nome;
                cmd.Parameters.Add(pnome);

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

        public void Alterar(Contatos pContatos, string pStrConexao, out int pId)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = pStrConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UPDATE_CONTATO";

                SqlParameter pnome = new SqlParameter("@NOME_CONTATO", SqlDbType.VarChar, 100);
                pnome.Value = pContatos.Nome;
                cmd.Parameters.Add(pnome);

                SqlParameter pid = new SqlParameter("@ID_CONTATO", SqlDbType.Int);
                pid.Value = pContatos.IdContato;
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

        public void DELETE(int pIdContato, string pStrConexao, out int pId)
        {
            SqlConnection cn = new SqlConnection();
            try
            {
                cn.ConnectionString = pStrConexao;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DELETE_CONTATO";

                SqlParameter pid = new SqlParameter("@ID_CONTATO", SqlDbType.Int);
                pid.Value = pIdContato;
                cmd.Parameters.Add(pid);

                cn.Open();
                cmd.ExecuteNonQuery();

                var RETVAL = (Int32)cmd.Parameters["RET_VALUE"].Value;

                if(RETVAL > 0)
                {
                    cmd.CommandText = "DELETE_EMAILTELEFONE";
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }

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
