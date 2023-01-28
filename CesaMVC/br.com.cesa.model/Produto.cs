using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesaMVC.br.com.cesa.model
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
        public int FornecedorId { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorCompra { get; set; }
        public DateTime Data { get; set; }
    }
}
