namespace NotebookBackend.Services;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAll();
    Task Add(T item);
    Task Remove(T item);

    Task<T?> GetById(int id);
    
    Task<IEnumerable<T>> GetPage(int page);
}