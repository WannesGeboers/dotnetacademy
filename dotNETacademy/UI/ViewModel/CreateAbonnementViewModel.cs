using dotNETacademy.Common.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dotNETacademy.ViewModel
{
    public class CreateAbonnementViewModel
    {
        public SelectList TypeJaarabonnement { get; set; }
        public Jaarabonnement Jaarabonnement { get; set; }
    }
}
