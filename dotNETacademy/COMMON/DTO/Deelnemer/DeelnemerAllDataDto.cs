using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.COMMON.DTO.Deelnemer
{
    public class DeelnemerAllDataDto:DeelnemerDto
    {
        public OpleidingDto Opleiding { get; set; }
        public ICollection<EvaluatieDto> Evaluaties { get; set; }
    }
}
