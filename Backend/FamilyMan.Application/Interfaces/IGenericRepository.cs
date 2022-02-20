namespace FamilyMan.Infrastructure.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetByIdAsync(string id);
    void Add(T entity);
    void Delete(T entity);
}