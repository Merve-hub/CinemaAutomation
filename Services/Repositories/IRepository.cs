using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Entities;

namespace Services.Repositories
{
    public interface IRepository<T> where T:BaseEntity
    {
        List<T> GetAll(object p);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        object ActiveMovieGenreVMs();
        dynamic GetActive();
        object GetMoviesByGenreId(int id);
    }
}
