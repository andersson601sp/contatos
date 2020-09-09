using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Contatos.Models;

namespace Web.Contatos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Lista(string pParam)
        {
            var strcnn = System.Configuration.ConfigurationManager.AppSettings["connectionString"].ToString();
            ContatosBLL contatos = new ContatosBLL(strcnn);
            DataTable result = contatos.CONSULTA(pParam);
            List<ContatosModel> lista = new List<ContatosModel>();

            foreach (DataRow row in result.Rows)
            {
                ContatosModel contato = new ContatosModel();
                contato.IDCONTATO = (int)row["ID_CONTATO"];
                contato.NOMECONTATO = row["NOME_CONTATO"].ToString();
                contato.ID = (int)row["ID"];
                contato.DSC = row["DSC"].ToString();
                contato.TIP = (int)row["TIP"];
                lista.Add(contato);
            }
            ListaContatos model = new ListaContatos();
            model.ContatosModelLista = lista;

            return PartialView(model);
        }

        public ActionResult Editar(ContatosModel model)
        {
            return View(model);
        }

        public ActionResult Excluir(ContatosModel model)
        {
            var strcnn = System.Configuration.ConfigurationManager.AppSettings["connectionString"].ToString();
            if (model.TIP == 1)
            {
                EmailBLL email = new EmailBLL(strcnn);
                email.Excluir(model.ID, out int retval);
            }
            else if (model.TIP == 2)
            {
                TelefoneBLL telefone = new TelefoneBLL(strcnn);
                telefone.Excluir(model.ID, out int retval);
            }
            return RedirectToAction("Lista");

        }
    }
}