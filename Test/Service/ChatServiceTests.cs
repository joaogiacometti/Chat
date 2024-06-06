using AutoFixture;
using AutoMapper;
using Business.Services;
using Core.Dtos;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Models;
using FluentAssertions;
using Moq;

namespace Test.Service;

public class ChatServiceTests
{
    private readonly ChatService _service;
    private readonly Mock<IChatRepository> _repo;
    private readonly IMapper _mapper;
    private readonly Fixture _fixture;


    public ChatServiceTests()
    {
        _mapper = new MapperConfiguration(mc => { mc.AddProfile<ChatMapper>(); }).CreateMapper();
        _repo = new Mock<IChatRepository>();
        _fixture = new Fixture();

        _service = new ChatService(_repo.Object, _mapper);
    }

    [Fact]
    public async Task GetById_ShouldThrowIfNotFound()
    {
        var invalidId = "test";
        _repo.Setup(r => r.GetById(It.IsAny<string>())).ReturnsAsync((Chat)null);

        Func<Task> action = async () => await _service.GetById(invalidId);

        await action.Should().ThrowAsync<ChatNotFoundException>().WithMessage("Chat not found");
    }

    [Fact]
    public async Task GetById_ShouldNotThrowIfFound()
    {
        var fakeChat = _fixture.Create<Chat>();
        _repo.Setup(r => r.GetById(It.IsAny<string>())).ReturnsAsync(fakeChat);

        Func<Task> action = async () => await _service.GetById(fakeChat.Id);

        await action.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Update_ShouldThrowIfNotFound()
    {
        var invalidChat = _fixture.Create<ChatUpdateDto>();
        _repo.Setup(r => r.GetById(It.IsAny<string>())).ReturnsAsync((Chat)null);

        Func<Task> action = async () => await _service.Update(invalidChat);

        await action.Should().ThrowAsync<ChatNotFoundException>().WithMessage("Chat not found");
    }

    [Fact]
    public async Task Update_ShouldNotThrowIfFound()
    {
        var fakeChat = _fixture.Create<Chat>();
        var fakeUpdateChat = _fixture.Create<ChatUpdateDto>();
        _repo.Setup(r => r.GetById(It.IsAny<string>())).ReturnsAsync(fakeChat);

        Func<Task> action = async () => await _service.Update(fakeUpdateChat);

        await action.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Delete_ShouldThrowIfNotFound()
    {
        var invalidId = "test";
        _repo.Setup(r => r.GetById(It.IsAny<string>())).ReturnsAsync((Chat)null);

        Func<Task> action = async () => await _service.Delete(invalidId);

        await action.Should().ThrowAsync<ChatNotFoundException>().WithMessage("Chat not found");
    }

    [Fact]
    public async Task Delete_ShouldNotThrowIfFound()
    {
        var fakeChat = _fixture.Create<Chat>();

        _repo.Setup(r => r.GetById(It.IsAny<string>())).ReturnsAsync(fakeChat);

        Func<Task> action = async () => await _service.Delete(fakeChat.Id);

        await action.Should().NotThrowAsync();
    }
}