using Core.Interfaces.Repositories;
using Core.Models;
using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class MessageRepository(ChatContext context) : IMessageRepository
{
    private readonly ChatContext _context = context;

    public async Task<IEnumerable<Message>> GetAll()
    {
        return await _context.Messages.ToListAsync();
    }

    public async Task<Message?> GetById(string id)
    {
        var messageDb = await _context.Messages
            .Where(m => m.Id == id).FirstOrDefaultAsync();

        return messageDb; 
    }

    public async Task<IEnumerable<Message>> GetByUserId(string id)
    {
        return await _context.Messages
            .Where(m => m.UserId == id)
            .ToListAsync();
    }

    public async Task<IEnumerable<Message>> GetByChatId(string chatId)
    {
        return await _context.Messages
            .Where(m => m.ChatId == chatId)
            .ToListAsync();
    }

    public async Task Send(Message message)
    {
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Message message)
    {
        _context.Messages.Entry(message).State = EntityState.Modified;
        
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Message message)
    {
        _context.Entry(message).State = EntityState.Deleted;
        
        await _context.SaveChangesAsync();
    }
}