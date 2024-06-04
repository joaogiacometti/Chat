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

    public async Task<Message> GetById(string id)
    {
        var messageDb = await _context.Messages
            .Where(m => m.Id == id).FirstOrDefaultAsync() ?? throw new Exception("Message not found");

        return messageDb; 
    }

    public async Task<IEnumerable<Message>> GetByUserId(string id)
    {
        return await _context.Messages
            .Where(m => m.UserId == id)
            .ToListAsync();
    }

    public async Task Send(Message message)
    {
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Message message)
    {
        var messageDb = await GetById(message.Id);

        messageDb.Content = message.Content;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(string id)
    {
        var messageDb = await GetById(id);

        _context.Messages.Remove(messageDb);
        await _context.SaveChangesAsync();
    }
}