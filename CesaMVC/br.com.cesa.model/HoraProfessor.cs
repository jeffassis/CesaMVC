using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesaMVC.br.com.cesa.model
{
    public class HoraProfessor
    {
        public int IdHoraProfessor { get; set; }
        public int HorarioId { get; set; }
        public int DisciplinaId { get; set; }
        public int TurmaId { get; set; }
    }
}
