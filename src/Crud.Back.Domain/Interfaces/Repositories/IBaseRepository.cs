using System;
using System.Collections.Generic;
using System.Text;
using Crud.Back.Domain.Entities;

namespace Crud.Back.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(object id);
        void Insert(T entidade);
        void Update(T entidade);
        Task<T> Delete(T entidade);
        int Commit();
        void Dispose();
    }
}
