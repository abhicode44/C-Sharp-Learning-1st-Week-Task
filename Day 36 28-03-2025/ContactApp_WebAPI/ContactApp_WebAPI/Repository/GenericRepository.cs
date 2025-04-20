using ContactApp_WebAPI.Data;
using ContactApp_WebAPI.Interface;
using Microsoft.EntityFrameworkCore;

namespace ContactApp_WebAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {   
        private readonly MyContext _context;
        private readonly DbSet<T> _dbset;
        public GenericRepository( MyContext context) 
        { 
              _context = context;
              _dbset = context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbset.ToList(); 
        }

        public  T GetById (int id)
        {
            return  _dbset.Find(id);
        }

        public async Task Add(T t)
        {
            await _dbset.AddAsync(t);
            _context.SaveChanges();
        }

        public void Delete(T entity)    
        { 
            _dbset.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity) 
        { 
            _dbset.Attach(entity);
            
            _context.SaveChanges();
        }
        

    }

   
}
