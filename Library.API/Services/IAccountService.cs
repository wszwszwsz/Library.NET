using Library.Core.DTO;
using Library.Infrastructure.Repository;

namespace Library.API.Services;

public interface IAccountService
{
    Task<IEnumerable<AccountBasicInformationResponseDto>> GetAllAccountBasinInfosAsync();
    Task AddNewAccount(AccountCreationRequestDto dto); 
    
}