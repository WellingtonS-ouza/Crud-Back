using Crud.Back.Domain.Interfaces.Repositories;
using Crud.Back.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Crud.Back.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly CrudBackContext _context;

        public BaseRepository(CrudBackContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Selecionar: " + ex.Message);
            }
        }

        public virtual async Task<T> GetByIdAsync(object id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Selecionar: " + ex.Message);
            }
        }

        public virtual async Task InsertAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Inserir: " + ex.Message);
            }
        }

        public virtual void Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Alterar: " + ex.Message);
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Remover: " + ex.Message);
            }
        }

        public virtual async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Salvar: " + ex.Message);
            }
        }
    }

}
