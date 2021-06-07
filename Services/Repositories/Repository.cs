using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();

        }

        public object ActiveMovieGenreVMs()
        {
            throw new NotImplementedException();
        }

        public void Create(T entity)
        {
            if(entity !=null)
            {
                entity.CreatedDate = DateTime.Now;
                entities.Add(entity);
                context.SaveChanges();
            }
        }
        

        public void Delete(T entity)
        {
            entities.Remove(entity);
            context.SaveChanges();
        }

        public dynamic GetActive()
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return entities.ToList();
        }

        public List<T> GetAll(object p)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            return entities.Find(id);
        }

        public object GetMoviesByGenreId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
            context.SaveChanges();
        }
    }

}
