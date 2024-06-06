using System.Collections;
using AutoMapper;
using Core.Dtos;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;

namespace Business.Services;

public class MessageService(IMessageRepository repo, IMapper mapper) : IMessageService
{
    private readonly IMessageRepository _repo = repo;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<MessageDto>> GetAll()
    {
        var list = await _repo.GetAll();

        return _mapper.Map<IEnumerable<MessageDto>>(list);
    }

    public async Task<MessageDto> GetById(string id)
    {
        var message = await _repo.GetById(id);

        return _mapper.Map<MessageDto>(message);
    }

    public async Task<IEnumerable<MessageDto>> GetByUserId(string id)
    {
        var list = await _repo.GetByUserId(id);

        return _mapper.Map<IEnumerable<MessageDto>>(list);
    }

    public async Task Send(MessageCreateDto messageDto)
    {
        var message = _mapper.Map<Message>(messageDto);
        message.Id = Guid.NewGuid().ToString();

        await _repo.Send(message);
    }

    public async Task Update(MessageUpdateDto messageDto)
    {
        var message = _mapper.Map<Message>(messageDto);

        await _repo.Update(message);
    }

    public async Task Delete(string id)
    {
        await _repo.Delete(id);
    }
}