using dotNETacademy.COMMON.DTO.Deelnemer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.COMMON.DTO.Evaluatie
{
    public class EvaluatieAllDataDto:EvaluatieDto
    {
        public DeelnemerDto Deelnemer { get; set; }
    }
}
