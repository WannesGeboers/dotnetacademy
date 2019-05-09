using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.COMMON.DTO.Opleiding
{
    public class OpleidingCreateEditDto : ICreateUpdateDto
    {
        public string Beschrijving { get; set; }
        public TypeOpleidingDto Type { get; set; }
        public int Credits { get; set; }
    }
}
