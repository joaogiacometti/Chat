using Core.Models;

namespace Core.Interfaces.Repositories;

public interface IMessageRepository
{
    Task<IEnumerable<Message>> GetAll();
    
    Task<Message> GetById(string id);
    
    Task<IEnumerable<Message>> GetByUserId(string id);

    Task Send(Message message);

    Task Update(Message message);

    Task Delete(string id);
}