using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNETacademy.Areas.Identity.Data;
using dotNETacademy.Common.Entities;
using dotNETacademy.Data.Repository;

namespace dotNETacademy.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        
        private GenericRepository<Credit> iCreditRepository;
        private GenericRepository<Deelnemer> iDeelnemerRepository;
        private GenericRepository<Factuur> iFactuurRepository;
        private GenericRepository<Jaarabonnement> iJaarabonnementRepository;
        private GenericRepository<Customer> iCustomerRepository;
        private GenericRepository<Opleiding> iOpleidingRepository;
        private GenericRepository<TypeJaarabonnement> iTypeJaarabonnementRepository;
        private GenericRepository<TypeOpleiding> iTypeOpleidingRepository;

        public virtual GenericRepository<Credit> CreditRepository
        {
            get
            {
                //nieuwe repository aanmaken indien er nog geen is
                if (this.iCreditRepository == null)
                {
                    this.iCreditRepository = new GenericRepository<Credit>(_context);
                }
                return iCreditRepository;
            }
        }
        public virtual GenericRepository<Deelnemer> DeelnemerRepository
        {
            get
            {
                //nieuwe repository aanmaken indien er nog geen is
                if (this.iDeelnemerRepository == null)
                {
                    this.iDeelnemerRepository = new GenericRepository<Deelnemer>(_context);
                }
                return iDeelnemerRepository;
            }
        }
        public virtual GenericRepository<Factuur> FactuurRepository
        {
            get
            {
                //nieuwe repository aanmaken indien er nog geen is
                if (this.iFactuurRepository == null)
                {
                    this.iFactuurRepository = new GenericRepository<Factuur>(_context);
                }
                return iFactuurRepository;
            }
        }
        public virtual GenericRepository<Jaarabonnement> JaarabonnementRepository
        {
            get
            {
                //nieuwe repository aanmaken indien er nog geen is
                if (this.iJaarabonnementRepository == null)
                {
                    this.iJaarabonnementRepository = new GenericRepository<Jaarabonnement>(_context);
                    
                }
                return iJaarabonnementRepository;
            }
        }
        public virtual GenericRepository<Customer> CustomerRepository
        {
            get
            {
                //nieuwe repository aanmaken indien er nog geen is
                if (this.iCustomerRepository == null)
                {
                    this.iCustomerRepository = new GenericRepository<Customer>(_context);
                }
                return iCustomerRepository;
            }
        }
        public virtual GenericRepository<Opleiding> OpleidingRepository
        {
            get
            {
                //nieuwe repository aanmaken indien er nog geen is
                if (this.iOpleidingRepository == null)
                {
                    this.iOpleidingRepository = new GenericRepository<Opleiding>(_context);
                }
                return iOpleidingRepository;
            }
        }
        public virtual GenericRepository<TypeJaarabonnement> TypeJaarabonnementRepository
        {
            get
            {
                //nieuwe repository aanmaken indien er nog geen is
                if (this.iTypeJaarabonnementRepository == null)
                {
                    this.iTypeJaarabonnementRepository = new GenericRepository<TypeJaarabonnement>(_context);
                }
                return iTypeJaarabonnementRepository;
            }
        }
        public virtual GenericRepository<TypeOpleiding> TypeOpleidingRepository
        {
            get
            {
                //nieuwe repository aanmaken indien er nog geen is
                if (this.iTypeOpleidingRepository == null)
                {
                    this.iTypeOpleidingRepository = new GenericRepository<TypeOpleiding>(_context);
                }
                return iTypeOpleidingRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
