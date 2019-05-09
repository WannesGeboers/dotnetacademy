using dotNETacademy.Common.Entities;
using dotNETacademy.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.ViewModel
{
    public class CreateEvaluatie
    {        
        public Evaluatie Evaluatie { get; set; }       
        public IFormFile Bestand { set; get; }        
    }
}
