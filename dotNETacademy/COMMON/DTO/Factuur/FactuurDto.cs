using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.COMMON.DTO.Factuur
{
    public class FactuurDto
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public String Omschrijving { get; set; }
        public decimal Prijs { get; set; }
        public bool IsVereffend { get; set; }
        public string BestandUrl { get; set; }

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
