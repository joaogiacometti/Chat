using Core.Models;

namespace Core.Interfaces.Repositories;

public interface IAccountRepository
{
    Task Create(Account account);

    Task<List<Account>> GetAll();

    Task<Account> GetById(int id);

    Task Update(Account newAccount);

    Task Delete(int id);
}