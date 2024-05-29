using Core.Interfaces.Repositories;
using Core.Models;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class AccountRepository(ChatContext context) : IAccountRepository
{
    private readonly ChatContext _context = context;
    
    public async Task Create(Account account)
    {
        _context.Add(account);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Account>> GetAll()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task<Account> GetById(int id)
    {
        return await _context.Accounts.SingleOrDefaultAsync(a => a.Id == id) 
               ?? throw new Exception("Account not found");
    }

    public async Task Update(Account newAccount)
    {
        _context.Entry(newAccount).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        var account = await GetById(id);

        _context.Entry(account).State = EntityState.Deleted;

        await _context.SaveChangesAsync();
    }
}