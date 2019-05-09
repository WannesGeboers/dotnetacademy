using dotNETacademy.COMMON.DTO.Factuur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.COMMON.DTO.Jaarabonnement
{
    public class JaarabonnementAllDataDto:JaarabonnementDto
    {
        public TypeJaarabonnementDto JaarAbonnement { get; set; }
        public List<FactuurDto> Facturen { get; set; }
    }
}
