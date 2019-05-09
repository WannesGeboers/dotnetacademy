using System;
using System.Collections.Generic;
using System.Text;
using dotNETacademy.Areas.Identity.Data;
using dotNETacademy.Common.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using dotNETacademy.Models;

namespace dotNETacademy.Data
{
    public class ApplicationDbContext : IdentityDbContext<Customer>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Opleiding> Opleidingen { get; set; }
        public DbSet<Deelnemer> Deelnemers { get; set; }
        public DbSet<Factuur> Facturen { get; set; }
        public DbSet<Jaarabonnement> Jaarabonnementen { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<TypeJaarabonnement> TypeJaarabonnementen { get; set; }
        public DbSet<TypeOpleiding> TypeOpleidingen { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Opleiding>().ToTable("Opleiding");
            builder.Entity<Deelnemer>().ToTable("Deelnemer");
            builder.Entity<Factuur>().ToTable("Factuur");
            builder.Entity<Jaarabonnement>().ToTable("Jaarabonnement");
           // builder.Entity<Customer>().ToTable("Customer");
            builder.Entity<Credit>().ToTable("Credit");
            builder.Entity<TypeJaarabonnement>().ToTable("TypeJaarabonnement");
            builder.Entity<TypeOpleiding>().ToTable("TypeOpleiding");
        }

        public DbSet<dotNETacademy.Models.Evaluatie> Evaluatie { get; set; }
    }
}
