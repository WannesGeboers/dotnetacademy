using System.ComponentModel.DataAnnotations;

namespace dotNETacademy.Common.Entities
{
    public class Credit: IBaseEntity
    {
        public int Id { get; set; }
        [Display(Name = "Prijs per credit")]
        public decimal PrijsPerCredit { get; set; }
    }
}
