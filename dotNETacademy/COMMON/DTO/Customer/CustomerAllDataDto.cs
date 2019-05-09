using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.COMMON.DTO.Customer
{
    public class CustomerAllDataDto:CustomerDto
    {
        public List<JaarabonnementDto> Jaarabonnementen { get; set; }
        public List<DeelnemerDto> Deelnemers { get; set; }
    }
}
