using Microsoft.EntityFrameworkCore;
using Crud.Back.Domain.Interfaces.Repositories;
using Crud.Back.Infra.Data.Context;


namespace IplanRio.Infrastructure.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar: " + ex.Message);
            }
        }

        public async Task<T> GetById(object id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao selecionar: " + ex.Message);
            }
        }

        public void Insert(T entidade)
        {
            try
            {
                _context.Set<T>().Add(entidade);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao inserir: " + ex.Message);
            }
        }

        public void Update(T entidade)
        {
            try
            {
                _context.Entry(entidade).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Alterar: " + ex.Message);
            }
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<T?> Delete(T id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null)
                return null; 

            try
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync(); 
                return entity; 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao excluir: " + ex.Message);
            }
        }


        #region

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }



        #endregion
    }
}