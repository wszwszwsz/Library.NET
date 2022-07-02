using Library.Infrastructure.Context;
using Library.Infrastructure.Entities;
using Library.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repository;

public class AccountRepository : IAccountRepository
{
    private readonly MainContext _mainContext;

    public AccountRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public async Task<IEnumerable<Account>> GetAll()
    {
        var accounts = await _mainContext.Accounts.ToListAsync();

        foreach (var account in accounts)
        {
            await _mainContext.Entry(account).Reference(x => x.Accounts).LoadAsync();
        }

        return accounts;
    }

    public async Task<Account> GetById(int id)
    {
        var account = await _mainContext.Accounts.SingleOrDefaultAsync(x => x.Id == id);
        if (account != null)
        {
            await _mainContext.Entry(account).Reference(x => x.Accounts).LoadAsync();
            return account;
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    public async Task Add(Account entity)
    {
        var accountToAdd = await _mainContext.Accounts.SingleOrDefaultAsync(x => x.Id == entity.Id);
        if (accountToAdd != null) 
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

    public async Task Update(Account entity)
    {
        var accountToUpdate = await _mainContext.Accounts.SingleOrDefaultAsync(x => x.Id == entity.Id);

        if (accountToUpdate == null)
        {
            throw new NotImplementedException();
        }

        accountToUpdate.Email = entity.Email;
        accountToUpdate.FirstName = entity.FirstName;
        accountToUpdate.LastName = entity.LastName;
        accountToUpdate.PhoneNumber = entity.PhoneNumber;
        accountToUpdate.BookId = entity.BookId;
        accountToUpdate.DateOfUpDate = DateTime.UtcNow;

        await _mainContext.SaveChangesAsync();

    }

    public async Task DeleteById(int id)
    {
        var accountToDelete = await _mainContext.Accounts.SingleOrDefaultAsync(x => x.Id == id);
        if (accountToDelete != null)
        {
            _mainContext.Accounts.Remove(accountToDelete);
            await _mainContext.SaveChangesAsync();
        }
        else
        {
            throw new EntityNotFoundException();
        }
    }
}