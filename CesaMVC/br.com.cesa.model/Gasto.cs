﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CesaMVC.br.com.cesa.model
{
    public class Gasto
    {
        public int IdGasto { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public string Funcionario { get; set; }
        public DateTime Data { get; set; }
    }
}
