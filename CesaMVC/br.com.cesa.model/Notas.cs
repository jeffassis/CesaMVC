using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesaMVC.br.com.cesa.model
{
    public class Notas
    {
        public  int IdNota { get; set; }
        public  int AlunoId { get; set; }
        public  int DisciplinaId { get; set; }
        public  int TurmaId { get; set; }
        public  int Bimestre { get; set; }
        public  string Tipo { get; set; }
        public  decimal Nota { get; set; }
    }
}
