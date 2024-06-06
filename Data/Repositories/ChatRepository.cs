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

    public async Task<Chat> GetById(string id)
    {
        return await _context.Chats
            .Where(c => c.Id == id).FirstOrDefaultAsync() ?? throw new Exception("Chat not found");
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
        var chatDb = await GetById(chat.Id);

        chatDb.Title = chat.Title;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(string id)
    {
        var chatDb = await GetById(id);

        _context.Chats.Remove(chatDb);
        await _context.SaveChangesAsync();
    }
}