using Store.DAL.Entities;
using Store.Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Interfaces
{
    public interface IGenericRepository<Entity,Key> where Entity:BaseEntity<Key>
    {
        public Task<IEnumerable<Entity>> GetAllAsync();

        public Task<IEnumerable<Entity>> GetAllWithSpecificationAsync(ISpecification<Entity> specs);
        public Task<Entity> GetByIdWithSpecificationAsync(ISpecification<Entity>specs);

        public Task<Entity> GetByIdAsync(Key? id);

        public Task AddAsync(Entity entity);

        public void Delete(Entity entity);

        public void Update(Entity entity);


        
    }
}
