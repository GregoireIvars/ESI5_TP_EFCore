using System.Linq.Expressions;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

    void Add(T entity);
    void Update(T entity);
    void Remove(int id);
    void AddRange(IEnumerable<T> entities);
    void RemoveRange(IEnumerable<T> entities);

    int SaveChanges();
}
