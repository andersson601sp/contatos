using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Email
    {
        private readonly int _idEmail;
        private int _idContato;
        private string _mail;

        public int IdEmail
        {
            get { return _idEmail; }
        }

        public int IdContato
        {
            get { return _idContato; }
            set { _idContato = value; }
        }

        public string Mail
        {
            get { return _mail; }
            set { _mail = value; }
        }
    }
}
