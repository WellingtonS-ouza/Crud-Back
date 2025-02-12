using Crud.Back.Domain.Interfaces.Repositories;
using Crud.Back.Domain.Interfaces.Service;

namespace Crud.Back.Application.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task InsertAsync(T entity)
        {
            await _repository.InsertAsync(entity);
        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }
    }
}
