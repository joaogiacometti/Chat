using AutoFixture;
using AutoMapper;
using Business.Services;
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Models;
using FluentAssertions;
using Moq;

namespace Test.Service;

public class MessageServiceTests
{
    private MessageService _service;
    private Mock<IMessageRepository> _repo;
    private IMapper _mapper;
    private Fixture _fixture;
    
    public MessageServiceTests()
    {
        _mapper = new MapperConfiguration(mc =>
        {
            mc.AddProfile<MessageMapper>();
        }).CreateMapper();
        _repo = new Mock<IMessageRepository>();
        _fixture = new Fixture();

        _service = new MessageService(_repo.Object, _mapper);
    }
    
    [Fact]
    public async Task GetById_ShouldThrowIfNotFound()
    {
        var invalidId = "test";
        _repo.Setup(r => r.GetById(It.IsAny<string>())).ReturnsAsync((Message)null);
        
        Func<Task> action = async () => await _service.GetById(invalidId);

        await action.Should().ThrowAsync<MessageNotFoundException>()
            .WithMessage("Message not found");
    }
    
    [Fact]
    public async Task GetById_ShouldNotThrowIfFound()
    {
        var fakeMessage = _fixture.Create<Message>();
        
        _repo.Setup(r => r.GetById(It.IsAny<string>())).ReturnsAsync(fakeMessage);
        
        Func<Task> action = async () => await _service.GetById(fakeMessage.Id);

        await action.Should().NotThrowAsync();
    }
}