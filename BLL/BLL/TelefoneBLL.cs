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
    public class TelefoneBLL
    {
        string conStr = "";
        public TelefoneBLL(string _conStr)
        {
            conStr = _conStr;
        }

        public void Incluir(Telefone telefone, out int retval)
        {
            if(telefone.Tel.Trim().Length == 0)
            {
                throw new Exception("O Telefone do Contato é Obrigatório");
            }

            if (telefone.IdContato > 1)
            {
                throw new Exception("O Nome do Contato é Obrigatório");
            }

            TelefoneDAL obj = new TelefoneDAL();
            obj.Incluir(telefone, conStr, out retval);
        }

        public void Alterar(Telefone telefone, out int retval)
        {
            if (telefone.Tel.Trim().Length == 0)
            {
                throw new Exception("O Telefone do Contato é Obrigatório");
            }

            if (telefone.IdContato > 1)
            {
                throw new Exception("O Nome do Contato é Obrigatório");
            }

            TelefoneDAL obj = new TelefoneDAL();
            obj.Alterar(telefone, conStr, out retval);
        }


        public void Excluir(int pId, out int retval)
        {
            if (pId < 1)
            {
                throw new Exception("Selecione antes de excluir.");
            }

            TelefoneDAL obj = new TelefoneDAL();
            obj.DELETE(pId, conStr, out retval);

        }
    }
}
