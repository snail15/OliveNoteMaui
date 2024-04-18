using System.Data.Common;
using System.Linq.Expressions;
using OliveNoteMaui.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace OliveNoteMaui.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
{

    public event EventHandler<T>? OnItemAdded;
    public event EventHandler<T>? OnItemUpdated;
    
    private SQLiteAsyncConnection _connection;
    private string _statusMessage;
    
    public BaseRepository()
    {
        //Task.Run(async () => await CreateConnectionAsync());
    }

    public async Task<List<T>> GetItemsAsync()
    {
        try
        {
            await CreateConnectionAsync();
            // return await _connection.Table<T>().ToListAsync();
            return await _connection.GetAllWithChildrenAsync<T>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task<List<T>> GetItemsAsync(Expression<Func<T, bool>> predicate)
    {
        try
        {
            return await _connection.GetAllWithChildrenAsync<T>(predicate);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task AddItemAsync(T item)
    {
        int rowsAdded;
        try
        {
            //await CreateConnectionAsync();
            await _connection.InsertWithChildrenAsync(item);
            OnItemAdded?.Invoke(this, item);
            
        }
        catch (DbException ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
    public async Task UpdateItemAsync(T item)
    {
        try
        {
            //await CreateConnectionAsync();
            await _connection.UpdateWithChildrenAsync(item);
            OnItemUpdated?.Invoke(this, item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task AddOrUpdateItemAsync(T item)
    {
        if (item.Id == 0)
        {
            await AddItemAsync(item);
        }
        else
        {
            await UpdateItemAsync(item);
        }
    }
    public async Task<T> GetItemAsync(int id)
    {
        try
        {
            //await CreateConnectionAsync();
            return await _connection.FindWithChildrenAsync<T>(id);
            return await _connection.Table<T>().FirstOrDefaultAsync(note => note.Id == id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public Task<T> GetItemAsync(Expression<Func<T, bool>> predicate)
    {
        try
        {
            return _connection.GetWithChildrenAsync<T>(predicate);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public async Task DeleteItemAsync(T item)
    {
        try
        {
            //await CreateConnectionAsync();
            await _connection.DeleteAsync<T>(item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async void Dispose()
    {
        await _connection.CloseAsync();
    }
    
    private async Task CreateConnectionAsync()
    {
        try
        {
            if (_connection is not null)
            {
                return;
            }

            _connection = new SQLiteAsyncConnection(AppSettings.DatabasePath, AppSettings.FLAGS);
            await _connection.DropTableAsync<Note>();
            await _connection.DropTableAsync<Olive>();
            await _connection.CreateTableAsync<Note>();
            await _connection.CreateTableAsync<Olive>();
        
            //If note table or olive table is empty, insert default data
            //Get dateonly object for 12/31/23


            var olive = new Olive()
            {
                Name = "First Olive",
                Imported = new DateTime(1986, 8, 13),
                Planted = new DateTime(2021, 1, 29),
                Origin = OliveOrigin.Korea
            };
            
            await InsertIfEmptyAsync<Olive>(olive);
            
            
            
            // var noteUpdate = await _connection.Table<Note>().FirstOrDefaultAsync(note => note.Id == 1);
            var oliveUpdate = await _connection.Table<Olive>().FirstOrDefaultAsync(olive => olive.Id == 1);
            
            await InsertIfEmptyAsync<Note>(new Note()
            {
                NoteContent = "This is a test note for the first olive.",
                Olive = oliveUpdate
            });
            
            // noteUpdate.OliveId = oliveUpdate.Id;
            // await UpdateItemAsync(noteUpdate);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        


    }
    
    private async Task InsertIfEmptyAsync<T>(T item) where T : new()
    {
        if (await _connection.Table<T>().CountAsync() == 0)
        {
            await _connection.InsertWithChildrenAsync(item);
        }
    }
    
}
