using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.COMMON.DTO.Evaluatie
{
    public class EvaluatieCreateEditDto
    {
        public DateTime Datum { get; set; } = DateTime.Now;
        public string Omschrijving { get; set; }
        public double Punt { get; set; }
        public string BestandLocatie { get; set; }
        public int DeelnemerId { get; set; }
    }
}
