using Core.Interfaces.Repositories;
using Core.Models;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ChatRepository(ChatContext context) : IChatRepository
{
    private readonly ChatContext _context = context;

    public async Task<IEnumerable<Chat>> GetAll()
    {
        return await _context.Chats.ToListAsync();
    }

    public async Task<Chat?> GetById(string id)
    {
        return await _context.Chats
            .Where(c => c.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Chat>> GetByUserId(string id)
    {
        return await _context.Chats
            .Where(c => c.UserId == id)
            .ToListAsync();
    }

    public async Task Create(Chat chat)
    {
        _context.Chats.Add(chat);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Chat chat)
    {
        _context.Entry(chat).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Chat chat)
    {
        _context.Entry(chat).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }
}