using Microsoft.EntityFrameworkCore;
using Store.DAL.Contexts;
using Store.DAL.Entities;
using Store.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Repositories
{
    public class GenericRepository<Entity, Key> : IGenericRepository<Entity, Key> where Entity :BaseEntity<Key>  
    {

        private readonly StoreDbcontext _context;
        public GenericRepository(StoreDbcontext context)
        {
            _context = context;
        }
        public async Task AddAsync(Entity entity)
        {
           await _context.Set<Entity>().AddAsync(entity);
        }

        public void Delete(Entity entity)
        {
            _context.Set<Entity>().Remove(entity);
        }

        public async Task<IEnumerable<Entity>> GetAllAsync()
        {
            return await _context.Set<Entity>().ToListAsync();

        }

        public async Task<Entity> GetByIdAsync(Key? Id)
        {
            return await _context.Set<Entity>().FindAsync(Id);
        }

        public void Update(Entity entity)
        {
            _context.Set<Entity>().Update(entity);
        }
    }
}
