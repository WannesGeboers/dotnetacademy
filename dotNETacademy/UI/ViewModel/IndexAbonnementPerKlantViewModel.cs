using dotNETacademy.Areas.Identity.Data;
using dotNETacademy.Common.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.ViewModel
{
    public class IndexAbonnementPerKlantViewModel
    {
        public ICollection<Jaarabonnement> Jaarabonnementen { get; set; }
        public Customer Customer { get; set; }
        public Jaarabonnement Jaarabonnement { get; set; }
        public int AantalAbonnementen { get { return Jaarabonnementen.Count; } }
        public SelectList TypeJaarabonnement { get; set; }
    }
}
