using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Contatos
    {
        private readonly int _idContato;
        private string _nome;

        public int IdContato
        {
            get { return _idContato;  }
        }

        public string Nome 
        { 
            get {return _nome; } 
            set { _nome = value; } 
        }

    }
}
