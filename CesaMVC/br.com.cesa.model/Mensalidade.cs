using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesaMVC.br.com.cesa.model
{
    public class Mensalidade
    {
        public int IdMensalidade { get; set; }
        public int TurmaId { get; set; }
        public int AlunoId { get; set; }
        public int ServicoId { get; set; }
        public DateTime Data { get; set; }
        public string Funcionario { get; set; }
        public string Situacao { get; set; }
        public string Mes { get; set; }
        public string Observacao { get; set; }
    }
}
