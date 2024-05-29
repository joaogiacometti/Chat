using AutoMapper;
using Core.Dtos;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Business.Services;

public class AccountService(IMapper mapper, IAccountRepository repo) : IAccountService
{
    private readonly IAccountRepository _repo = repo;
    private readonly IMapper _mapper = mapper;

    public async Task Create(AccountRegisterDto accountRegisterDto)
    {
        var newAccount = _mapper.Map<Account>(accountRegisterDto);

        await _repo.Create(newAccount);
    }

    public async Task<List<AccountDto>> GetAll()
    {
        var listDto = await _repo.GetAll();
        
        return _mapper.Map<List<AccountDto>>(listDto);
    }

    public async Task<AccountDto> GetById(int id)
    {
        var accountDto = await _repo.GetById(id);

        return _mapper.Map<AccountDto>(accountDto);
    }

    public async Task Update(int id, AccountUpdateDto newAccount)
    {
        var account = _mapper.Map<Account>(newAccount);
        account.Id = id;
        
        await _repo.Update(account);
    }

    public async Task Delete(int id)
    {
        await _repo.Delete(id);
    }
}