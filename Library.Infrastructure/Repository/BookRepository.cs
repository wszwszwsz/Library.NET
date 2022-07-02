using Library.Infrastructure.Context;
using Library.Infrastructure.Entities;
using Library.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repository;

public class BookRepository : IBookRepository
{
    private readonly MainContext _mainContext;

    public BookRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public async Task<IEnumerable<Book>> GetAll()
    {
        var books = await _mainContext.Book.ToListAsync();

        foreach (var book in books)
        {
            await _mainContext.Entry(book).Reference(x => x.Books).LoadAsync();
        }

        return books;
    }

    public async Task<Book> GetById(int id)
    {
        var book = await _mainContext.Book.SingleOrDefaultAsync(x => x.Id == id);
        if (book != null)
        {
            await _mainContext.Entry(book).Reference(x => x.Books).LoadAsync();
            return book;
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    public async Task Add(Book entity)
    {
        var bookToAdd = await _mainContext.Book.SingleOrDefaultAsync(x => x.Id == entity.Id);
        if (bookToAdd != null) 
        {
            entity.DateOfCreation = DateTime.UtcNow;
            await _mainContext.AddAsync(entity);
            await _mainContext.SaveChangesAsync();
        }
        else
        {
            throw new EntityNotFoundException();
        }

    }

    public async Task Update(Book entity)
    {
        var bookToUpdate = await _mainContext.Book.SingleOrDefaultAsync(x => x.Id == entity.Id);

        if (bookToUpdate == null)
        {
            throw new NotImplementedException();
        }

        bookToUpdate.Genre = entity.Genre;
        bookToUpdate.Name = entity.Name;
        bookToUpdate.DateOfUpDate = DateTime.UtcNow;

        await _mainContext.SaveChangesAsync();

    }

    public async Task DeleteById(int id)
    {
        var bookToDelete = await _mainContext.Book.SingleOrDefaultAsync(x => x.Id == id);
        if (bookToDelete != null)
        {
            _mainContext.Book.Remove(bookToDelete);
            await _mainContext.SaveChangesAsync();
        }
        else
        {
            throw new EntityNotFoundException();
        }
    }
}