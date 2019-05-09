using dotNETacademy.Common.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotNETacademy.Areas.Identity.Data
{
    public class Customer : IdentityUser
    {
        [PersonalData]
        public string Bedrijfsnaam { get; set; }
        [Display(Name = "Huidige credits")]
        public int HuidigeCredits { get; set; }
        public virtual List<Jaarabonnement> Jaarabonnementen { get; set; }
        public virtual List<Deelnemer> Deelnemers { get; set; }
    }
}
