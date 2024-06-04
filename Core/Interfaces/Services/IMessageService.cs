using Core.Dtos;

namespace Core.Interfaces.Services;

public interface IMessageService
{
    Task<IEnumerable<MessageDto>> GetAll();
    
    Task<MessageDto> GetById(string id);
    
    Task<IEnumerable<MessageDto>> GetByUserId(string id);

    Task Send(MessageDto messageDto);

    Task Update(MessageMutateDto messageDto);

    Task Delete(string id);
}