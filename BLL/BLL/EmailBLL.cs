using DAL;
using Modelos;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmailBLL
    {
        string conStr = "";
        public EmailBLL(string _conStr)
        {
            conStr = _conStr;
        }

        public void Incluir(Email email, out int retval)
        {
            if(email.Mail.Trim().Length == 0)
            {
                throw new Exception("O Email do Contato é Obrigatório");
            }

            if (email.IdContato > 1)
            {
                throw new Exception("O Nome do Contato é Obrigatório");
            }

            EmailDAL obj = new EmailDAL();
            obj.Incluir(email, conStr, out retval);
        }

        public void Alterar(Email email, out int retval)
        {
            if (email.Mail.Trim().Length == 0)
            {
                throw new Exception("O Email do Contato é Obrigatório");
            }

            EmailDAL obj = new EmailDAL();
            obj.Incluir(email, conStr, out retval);
        }


        public void Excluir(int pId, out int retval)
        {
            if (pId < 1)
            {
                throw new Exception("Selecione antes de excluir.");
            }

            EmailDAL obj = new EmailDAL();
            obj.DELETE(pId, conStr, out retval);

        }
    }
}
