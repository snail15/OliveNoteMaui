using System.Linq.Expressions;
using OliveNoteMaui.Models;

namespace OliveNoteMaui.Repositories;

public interface IBaseRepository<T> : IDisposable where T : TableData, new()
{
    event EventHandler<T> OnItemAdded;
    event EventHandler<T> OnItemUpdated;
    
    Task<List<T>> GetItemsAsync();
    Task<List<T>> GetItemsAsync(Expression<Func<T, bool>> predicate);
    Task AddItemAsync(T item);
    Task UpdateItemAsync(T item);
    Task AddOrUpdateItemAsync(T item);
    Task<T> GetItemAsync(int id);
    Task<T> GetItemAsync(Expression<Func<T, bool>> predicate);
    Task DeleteItemAsync(T item);
}
