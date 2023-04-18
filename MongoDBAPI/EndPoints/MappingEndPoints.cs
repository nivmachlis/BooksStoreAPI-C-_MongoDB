using BookStoreApi.Models;
using BookStoreApi.Services;

namespace MongoDBAPI.EndPoints
{
    public static class MappingEndPoints
    {
        public static void MapEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/books", async (BooksService booksService) =>
            {
                return Results.Ok(await booksService.GetAsync());
            });

            app.MapGet("/books/{bookName}", async (string bookName, BooksService booksService) =>
            {
                try
                {
                    var book = await booksService.GetAsync(bookName);

                    if (book is null)
                    {
                        return Results.NotFound();
                    }

                    return Results.Ok(book);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }

            });

            app.MapPost("/books", async (Book newBook, BooksService booksService) =>
            {
                try
                {
                    await booksService.CreateAsync(newBook);

                    return Results.Ok(newBook);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }

            });

            app.MapPut("/books/{bookName}", async (string bookName, Book updatedBook, BooksService booksService) =>
            {
                try
                {
                    var book = await booksService.GetAsync(bookName);

                    if (book is null)
                    {
                        return Results.NotFound();
                    }

                    updatedBook.Id = book.Id;

                    await booksService.UpdateAsync(bookName, updatedBook);

                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }

            });

            app.MapDelete("/books/{bookName}", async (string bookName, BooksService booksService) =>
            {
                try
                {
                    var book = await booksService.GetAsync(bookName);

                    if (book is null)
                    {
                        return Results.NotFound();
                    }

                    await booksService.RemoveAsync(bookName);

                    return Results.Ok();
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            });
        }
    }
}
