using API.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> GetAll();

        Task<T> GetById(Guid id);

        Task Create(T obj);

        Task Update(T obj, Guid id);

        Task Remove(Guid id);
    }
}