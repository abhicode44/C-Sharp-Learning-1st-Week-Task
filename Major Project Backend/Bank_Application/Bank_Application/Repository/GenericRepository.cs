using System.Linq.Expressions;
using Bank_Application.Data;
using Bank_Application.Interface.GernralRepository;
using Microsoft.EntityFrameworkCore;

namespace Bank_Application.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MyContext _context;
        private readonly DbSet<T> _dbset;
        public GenericRepository(MyContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public IQueryable<T> GetAll() 
        {
            return _context.Set<T>();
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<T> GetByConditionAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<T> GetByEmail(string email)
        {
            return await _context.Set<T>().FindAsync(email);
          // return _context.Employees.SingleOrDefault(e=>e.EmpEmail == email);
        }
    }
}
