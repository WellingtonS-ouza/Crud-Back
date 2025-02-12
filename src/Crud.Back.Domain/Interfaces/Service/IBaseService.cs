namespace Crud.Back.Domain.Interfaces.Service
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task InsertAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }


}
