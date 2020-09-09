using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Telefone
    {
        private readonly int _idTelefone;
        private int _idContato;
        private string _tel;

        public int IdTel
        {
            get { return _idTelefone; }
        }

        public int IdContato
        {
            get { return _idContato; }
            set { _idContato = value; }
        }

        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
    }
}
