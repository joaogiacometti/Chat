using Core.Dtos;

namespace Core.Interfaces.Services;

public interface IMessageService
{
    Task<IEnumerable<MessageDto>> GetAll();
    
    Task<MessageDto> GetById(string id);
    
    Task<IEnumerable<MessageDto>> GetByUserId(string id);

    Task<IEnumerable<MessageDto>> GetByChatId(string chatId);
    
    Task Send(MessageCreateDto messageDto);

    Task Update(MessageUpdateDto newMessageDto);

    Task Delete(string id);
}