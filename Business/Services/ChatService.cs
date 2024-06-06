using AutoMapper;
using Core.Dtos;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Models;

namespace Business.Services;

public class ChatService(IChatRepository repo, IMapper mapper) : IChatService
{
    private readonly IChatRepository _repo = repo;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<ChatDto>> GetAll()
    {
        var list = await _repo.GetAll();

        return _mapper.Map<IEnumerable<ChatDto>>(list);
    }

    public async Task<ChatDto> GetById(string id)
    {
        var chat = await _repo.GetById(id);

        return _mapper.Map<ChatDto>(chat);
    }

    public async Task<IEnumerable<ChatDto>> GetByUserId(string id)
    {
        var list = await _repo.GetByUserId(id);

        return _mapper.Map<IEnumerable<ChatDto>>(list);
    }

    public async Task Create(ChatCreateDto chatDto)
    {
        var chat = _mapper.Map<Chat>(chatDto);
        chat.Id = Guid.NewGuid().ToString();

        await _repo.Create(chat);
    }

    public async Task Update(ChatUpdateDto chatDto)
    {
        var chat = _mapper.Map<Chat>(chatDto);

        await _repo.Update(chat);
    }

    public async Task Delete(string id)
    {
        await _repo.Delete(id);
    }
}