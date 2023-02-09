using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesaMVC.br.com.cesa.model
{
    public class ItemVenda
    {
        public  int Id { get; set; }
        public  int Venda_id { get; set; }
        public  int Produto_id { get; set; }
        public  int Quantidade { get; set; }
        public  decimal SubTotal { get; set; }              
    }
}
