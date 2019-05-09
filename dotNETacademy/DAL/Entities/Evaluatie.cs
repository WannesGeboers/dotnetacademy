using dotNETacademy.Common.Entities;
using dotNETacademy.Models.Objecten;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.Models
{
    public class Evaluatie
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yy}")]
        public DateTime Datum { get; set; }
        public virtual Deelnemer Deelnemer { get; set; }
        public string Omschrijving { get; set; }
        public double Punt { get; set; }
        public string BestandLocatie { get; set; }
        public int DeelnemerId { get; set; }

        public Evaluatie()
        {
            Datum = DateTime.Now;
        }

    }
}
