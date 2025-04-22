namespace Bank_Application.Interface.GernralRepository
{
    public interface IGenericRepository<T> where T : class
    {
        public List<T> GetAll();

        public T GetById(int id);

        public T GetByEmail(string email);

        public Task Add(T entity);

        public void Update(T entity);

        public void Delete(T entity);
    }
}
