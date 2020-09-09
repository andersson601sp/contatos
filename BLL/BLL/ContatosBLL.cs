using DAL;
using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Deployment.Internal;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ContatosBLL
    {
        string conStr = "";
        public ContatosBLL(string _conStr)
        {
            conStr = _conStr;
        }

        public void Incluir(Contatos contato, out int retval)
        {
            if(contato.Nome.Trim().Length == 0)
            {
                throw new Exception("O Nome do Contato é Obrigatório");
            }

            ContatosDAL obj = new ContatosDAL();
            obj.Incluir(contato, conStr, out retval);
        }

        public void Alterar(Contatos contato, out int retval)
        {
            if (contato.Nome.Trim().Length == 0)
            {
                throw new Exception("O Nome do Contato é Obrigatório");
            }

            ContatosDAL obj = new ContatosDAL();
            obj.Alterar(contato, conStr, out retval);
        }


        public void Excluir(int pId, out int retval)
        {
            if (pId < 1)
            {
                throw new Exception("Selecione antes de excluir.");
            }

            ContatosDAL obj = new ContatosDAL();
            obj.DELETE(pId, conStr, out retval);

            if(retval > 0)
            {


                EmailDAL objEmail = new EmailDAL();
                objEmail.DELETE(pId, conStr, out retval);

                TelefoneDAL objTel = new TelefoneDAL();
                objTel.DELETE(pId, conStr, out retval);
            }
        }

        public DataTable CONSULTA(string pParam)
        {
            ConsultaDAL result = new ConsultaDAL();
            return result.CONSULTA(pParam, conStr);
        }
    }
}
