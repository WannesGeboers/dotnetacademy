using dotNETacademy.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotNETacademy.Common.Entities
{
    public class Deelnemer: IBaseEntity
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        [Display(Name = "Openstaande credits")]
        public int OpenstaandeCredits { get; set; }
        //lazy loading ophalen
        public virtual Opleiding Opleiding { get; set; }
        public string CustomerId { get; set; }
        public virtual ICollection<Evaluatie> Evaluaties { get; set; }
      
    }
}
