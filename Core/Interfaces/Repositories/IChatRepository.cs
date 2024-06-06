using Core.Models;

namespace Core.Interfaces.Repositories;

public interface IChatRepository
{
    Task<IEnumerable<Chat>> GetAll();
    
    Task<Chat?> GetById(string id);
    
    Task<IEnumerable<Chat>> GetByUserId(string id);

    Task Create(Chat chat);

    Task Update(Chat chat);

    Task Delete(Chat chat);
}