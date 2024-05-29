using Core.Dtos;
using Core.Models;

namespace Core.Interfaces.Services;

public interface IAccountService
{
    Task Create(AccountRegisterDto accountDto);

    Task<List<AccountDto>> GetAll();

    Task<AccountDto> GetById(int id);

    Task Update(int id, AccountUpdateDto accountDto);
    
    Task Delete(int id);
}