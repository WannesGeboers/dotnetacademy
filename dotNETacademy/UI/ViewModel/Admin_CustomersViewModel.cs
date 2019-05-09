using dotNETacademy.Areas.Identity.Data;
using dotNETacademy.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.ViewModel
{
    public class Admin_CustomersViewModel
    {


        public List<Customer> Customers { get; set; }
        public Jaarabonnement Jaarabonnement { get; set; }            
        public Customer Customer;
    }
}
