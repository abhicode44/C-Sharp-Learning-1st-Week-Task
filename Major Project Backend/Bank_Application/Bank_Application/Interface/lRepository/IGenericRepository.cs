using System.Linq.Expressions;

namespace Bank_Application.Interface.GernralRepository
{
    public interface IGenericRepository<T> where T : class
    {

        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task Update(T entity);

        Task<T> GetByEmail(string email);
        Task<T> GetByConditionAsync(Expression<Func<T, bool>> predicate);
        Task Delete(int id);
    }
}
