using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesaMVC.br.com.cesa.model
{
    public class Usuario
    {
        public int Iduser { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string Status { get; set; }
        public string Nivel { get; set; }
    }
}
