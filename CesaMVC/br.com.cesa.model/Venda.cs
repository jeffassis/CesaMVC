using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesaMVC.br.com.cesa.model
{
    public class Venda
    {
        public int Id { get; set; }
        public string Funcionario { get; set; }
        public DateTime Data_venda { get; set; }
        public decimal Total_venda { get; set; }
        public string Obs { get; set; }
        
    }
}
