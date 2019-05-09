using dotNETacademy.Areas.Identity.Data;
using dotNETacademy.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.ViewModel
{
    public class DetailsAbonnementViewModel
    {
        public Jaarabonnement Jaarabonnement { get; set; }
        public Customer Customer { get; set; }
    }
}
