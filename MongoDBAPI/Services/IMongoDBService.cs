using BookStoreApi.Models;

namespace MongoDBAPI.Services
{
    public interface IMongoDBService<T>
    {
        Task<List<T>> GetAsync();
        Task<T> GetAsync(string id);
        Task CreateAsync(T obj);
        Task UpdateAsync(string id, T updatedObj);
        Task RemoveAsync(string id);
    }
}

