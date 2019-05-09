using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.COMMON.DTO.Jaarabonnement
{
    public class JaarabonnementCreateUpdateDto
    {
        public decimal Prijs { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Einddatum { get; set; }
        public string CustomerId { get; set; }
        public int JaarAbonnementId { get; set; } //FK voor TypeJaarabonnement
    }
}
