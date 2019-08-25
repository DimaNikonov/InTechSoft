using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestTaskWebApi.DAL.Interfaces;

namespace TestTaskWebApi.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected AppContext dbContext;

        protected readonly DbSet<TEntity> entities;

        public Repository(AppContext dbContext)
        {
            this.dbContext = dbContext;
            this.entities = this.dbContext.Set<TEntity>();
        }
        public void Create(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            entities.Update(entity).State = EntityState.Deleted;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.entities;
        }

        public TEntity Get(int id)
        {
            return entities.Find(id);
        }

        public void Update(TEntity entity)
        {
            entities.Update(entity).State = EntityState.Modified;
        }
    }
}
