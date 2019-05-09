using dotNETacademy.Areas.Identity.Data;
using dotNETacademy.Common.Entities;
using System.Collections.Generic;

namespace dotNETacademy.ViewModel
{
    public class ListDeelnemersViewModel
    {
        public List<Deelnemer> Deelnemers { get; set; }
        public Deelnemer Deelnemer { get; set; }
        public Customer Customer { get; set; }
        public string Id { get; set; }
    }
}
