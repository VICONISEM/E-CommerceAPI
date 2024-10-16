using Store.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Entity, Key> Repository<Entity, Key>() where Entity : BaseEntity<Key>;

        public Task<int> CompeletAsync();

    }
}
