using dotNETacademy.Common.Entities;
using dotNETacademy.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.ViewModel
{
    public class EvaluatieViewModel
    {
        public int DeelnemerId { get; set; }
        public string DeelnemerNaam { get; set; }
        public Evaluatie Evaluatie { get; set; }
        public ICollection<Evaluatie> Evaluaties { get; set; }
        public IFormFile Bestand { set; get; }        
    }
}
