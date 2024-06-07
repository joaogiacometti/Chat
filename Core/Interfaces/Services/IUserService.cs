using Core.Dtos.User;

namespace Core.Interfaces.Services;

public interface IUserService
{
    Task Register(UserRegisterDto registerDto);
    
    Task<IEnumerable<UserDto>> GetAll();
}