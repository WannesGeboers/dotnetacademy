using dotNETacademy.Areas.Identity.Data;
using dotNETacademy.Common.Entities;
using dotNETacademy.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        GenericRepository<Credit> CreditRepository { get; }
        GenericRepository<Deelnemer> DeelnemerRepository { get; }
        GenericRepository<Factuur> FactuurRepository { get; }
        GenericRepository<Jaarabonnement> JaarabonnementRepository { get; }
        GenericRepository<Customer> CustomerRepository { get; }
        GenericRepository<Opleiding> OpleidingRepository { get; }
        GenericRepository<TypeJaarabonnement> TypeJaarabonnementRepository { get; }
        GenericRepository<TypeOpleiding> TypeOpleidingRepository { get; }
        void Save();
    }
}
