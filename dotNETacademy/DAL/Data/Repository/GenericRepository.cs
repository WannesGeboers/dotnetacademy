using dotNETacademy.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNETacademy.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
            where TEntity : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        //Zoek op string id (customer)
        public async Task<TEntity> GetByStringId(String id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Update(int id, TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void UpdateByStringId(string id, TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _context.Set<TEntity>().Remove(entity);
        }
    }
}
