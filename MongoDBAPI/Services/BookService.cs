using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBAPI.Modles;
using MongoDBAPI.Services;

namespace BookStoreApi.Services;

public class BooksService : IMongoDBService<Book>
{
    private readonly IMongoCollection<Book> _booksCollection;


    public BooksService(
        IOptions<DatabaseSettings> bookStoreDatabaseSettings)
    {
        _booksCollection = bookStoreDatabaseSettings.Value.ConnectToMonogo<Book>("Book");
    }

    public async Task<List<Book>> GetAsync() =>
        await _booksCollection.Find(_ => true).ToListAsync();

    public async Task<Book?> GetAsync(string bookName) =>
        await _booksCollection.Find(x => x.BookName == bookName).FirstOrDefaultAsync();

    public async Task CreateAsync(Book newBook)
    {
        newBook.Id = ObjectId.GenerateNewId().ToString();
        await _booksCollection.InsertOneAsync(newBook);
    }

    public async Task UpdateAsync(string bookName, Book updatedBook) =>
        await _booksCollection.ReplaceOneAsync(x => x.BookName == bookName, updatedBook);

    public async Task RemoveAsync(string bookName) =>
        await _booksCollection.DeleteOneAsync(x => x.BookName == bookName);
}