using DesafioAec.Domain.Interfaces;
using DesafioAec.Domain.Models;
using DesafioAec.Infra.DataContext;
using Microsoft.EntityFrameworkCore;


namespace DesafioAec.Infra.Repository
{
    public class Repository<TEntity>: IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDataContext _context;

        public Repository(AppDataContext context) 
        {
            _context= context;
        }

        
        public virtual void Dispose()
        {
            _context.Dispose();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            try
            {
                var query = _context.Set<TEntity>();
                return query.ToList();
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        public virtual TEntity GetById(int id)
        {
            try
            {
                var query = _context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefault();
                return query;
            }
            catch (Exception e)
            {

                throw;
            }
           
        }

        public virtual void remove(TEntity entity)
        {
            try
            {
                var query = _context.Set<TEntity>().Remove(entity);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public virtual void save(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public virtual void update(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
