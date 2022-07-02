using Library.Core.DTO;
using Library.Infrastructure.Entities;
using Library.Infrastructure.Repository;

namespace Library.API.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    public async Task<IEnumerable<AccountBasicInformationResponseDto>> GetAllAccountBasinInfosAsync()
    {
        var accounts = await _accountRepository.GetAll();
        return accounts.Select(x => new AccountBasicInformationResponseDto(
            x.FirstName,
            x.LastName,
            x.Email));
    }
    
    public async Task AddNewAccount(AccountCreationRequestDto dto)
    {
        await _accountRepository.Add(new Account
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        });
    }


}