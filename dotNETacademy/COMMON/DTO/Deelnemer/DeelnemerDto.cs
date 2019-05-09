using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.COMMON.DTO.Deelnemer
{
    public class DeelnemerDto
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public int OpenstaandeCredits { get; set; }
        public string CustomerId { get; set; }
    }
}
