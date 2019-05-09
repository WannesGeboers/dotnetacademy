using dotNETacademy.Areas.Identity.Data;
using dotNETacademy.Common.Entities;
using System.Collections.Generic;

namespace dotNETacademy.ViewModel
{
    public class CustomerInfoViewModel
    {
        public Customer Customer;
        public List<Deelnemer> Deelnemers { get; set; }
        public Jaarabonnement Jaarabonnement { get; set; }
        public int AantalDeelnemers { get; set; }
        public int AantalFacturen { get; set; }
        public decimal TotaalBedragFacturen { get; set; }
        public int HuidigeCredits { get; set; }
    }
}
