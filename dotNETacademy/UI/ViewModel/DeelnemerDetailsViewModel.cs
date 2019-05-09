using dotNETacademy.Areas.Identity.Data;
using dotNETacademy.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.ViewModel
{
    public class DeelnemerDetailsViewModel
    {

        public Deelnemer Deelnemer { get; set; }
        public Customer Customer { get; set; }
        public string StartDatum  { get; set; }
        public string EindDatum  { get; set; }
        public string Opleiding  { get; set; }
        public string TypeOpleiding  { get; set; }
        public int AantalEvaluaties { get { return Deelnemer.Evaluaties.Count; }}

    }
}
