using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotNETacademy.Common.Entities
{
    public class Jaarabonnement: IBaseEntity
    {
        public int Id { get; set; }
        public virtual TypeJaarabonnement JaarAbonnement { get; set; }
        public decimal Prijs { get; set; }
        [DataType(DataType.Date)]
        public DateTime Startdatum { get; set; }
        [DataType(DataType.Date)]
        public DateTime Einddatum { get; set; }
        public virtual List<Factuur> Facturen { get; set; }
        public string CustomerId { get; set; }

        public int JaarAbonnementId { get; set; }

        [Display(Name = "Date")]
        public string FormattedStartDatum
        {
            get
            {
                return this.Startdatum != null
                    ? Startdatum.ToString("dd-MMM-yy")
                    : "";
            }
        }

        [Display(Name = "Date")]
        public string FormattedEindDatum
        {
            get
            {
                return this.Einddatum != null
                    ? Einddatum.ToString("dd-MMM-yy")
                    : "";
            }
        }
    }
}
