using Store.DAL.Contexts;
using Store.DAL.Entities;
using Store.Repository.Interfaces;
using Store.Repository.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly StoreDbcontext _context;

        private Hashtable Repositories ;
        public UnitOfWork(StoreDbcontext context)
        {
            _context = context;
        }
        public async Task<int> CompeletAsync()
        {
          return  await _context.SaveChangesAsync();
        }

        public IGenericRepository<Entity, Key> Repository<Entity, Key>() where Entity : BaseEntity<Key>
        {
            if(Repositories is null)
            {
                Repositories = new Hashtable();
            }
            var TEntity=typeof(Entity).Name;
            if(!Repositories.ContainsKey(TEntity))
            {
                var RepoType = typeof(GenericRepository<,>);
                var repo=Activator.CreateInstance(RepoType.MakeGenericType(typeof(Entity),typeof(Key)),_context);
                Repositories.Add(TEntity,repo);
            }
            return (IGenericRepository<Entity, Key>)Repositories[TEntity];
           
        }
    }
}
