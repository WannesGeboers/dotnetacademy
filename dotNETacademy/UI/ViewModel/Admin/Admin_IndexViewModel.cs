using dotNETacademy.Areas.Identity.Data;
using dotNETacademy.Common.Entities;
using dotNETacademy.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.ViewModel
{
    public class Admin_IndexViewModel
    {
        public string Titel { get; set; }        
        public List<Customer> lijstCustomers { get; set; }        
        public string[] MaandenInJaar { get; set; }
        public List<Jaarabonnement> lijstJaarabonnementenInHuidigJaar { get; set; }
        public decimal TotaalPrijs { get; set; }
        public decimal TotaalGoud { get; set; }
        public decimal TotaalZilver { get; set; }
        public decimal TotaalBrons { get; set; }




}
}
