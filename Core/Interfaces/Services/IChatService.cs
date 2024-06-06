using Core.Dtos;

namespace Core.Interfaces.Services;

public interface IChatService
{
    Task<IEnumerable<ChatDto>> GetAll();
    
    Task<ChatDto> GetById(string id);
    
    Task<IEnumerable<ChatDto>> GetByUserId(string id);

    Task Create(ChatCreateDto chatDto);

    Task Update(ChatUpdateDto chatDto);

    Task Delete(string id);
}
