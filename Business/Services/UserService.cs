using AutoMapper;
using Core.Dtos.User;
using Core.Exceptions;
using Core.Interfaces.Services;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class UserService(UserManager<User> userManager, IMapper mapper) : IUserService
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IMapper _mapper = mapper;

    public async Task Register(UserRegisterDto registerDto)
    {
        var user = new User
        {
            UserName = registerDto.Email,
            Email = registerDto.Email
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded) throw new UserRegisterException(result);

        var roleResult = await _userManager.AddToRoleAsync(user, "User");

        if (!roleResult.Succeeded) throw new UserRegisterException(roleResult);
    }

    public async Task<IEnumerable<UserDto>> GetAll()
    {
        var list = await _userManager.Users.ToListAsync();

        return _mapper.Map<IEnumerable<UserDto>>(list);
    }
}