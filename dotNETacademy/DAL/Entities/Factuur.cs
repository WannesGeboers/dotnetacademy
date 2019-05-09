using System;
using System.ComponentModel.DataAnnotations;

namespace dotNETacademy.Common.Entities
{
    public class Factuur: IBaseEntity
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMM-yy}")]
        public DateTime Datum { get; set; }
        public String Omschrijving { get; set; }
        public decimal Prijs { get; set; }
        [Display(Name = "Is vereffend")]
        public bool IsVereffend { get; set; }
        public string BestandUrl { get; set; }

        [Display(Name = "Datum")]
        public string FormattedDatum
        {
            get
            {
                return Datum != null
                    ? Datum.ToString("dd-MMM-yy")
                    : "";
            }
        }
    }
}
