using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Contatos.Models
{
    public class ContatosModel
    {
        //C.ID_CONTATO, C.NOME_CONTATO, E.ID_EMAIL AS ID, E.EMAIL AS DSC, 1 AS TIP 
        public int IDCONTATO;
        public string NOMECONTATO;
        public int ID;
        public string DSC;
        public int TIP;
    }

    public class ListaContatos{
        public List<ContatosModel> ContatosModelLista;
    }

}