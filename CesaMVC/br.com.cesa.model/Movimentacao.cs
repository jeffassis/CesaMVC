using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesaMVC.br.com.cesa.model
{
    public class Movimentacao
    {
        public int IdMovimentacao { get; set; }
        public string Tipo { get; set; }
        public string Movimento { get; set; }
        public decimal Valor { get; set; }
        public string Funcionario { get; set; }
        public DateTime Data { get; set; }
        public int IdMovimento { get; set; }
    }
}
