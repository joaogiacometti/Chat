using Microsoft.AspNetCore.Identity;

namespace Core.Exceptions;

public class UserRegisterException : Exception
{
    public UserRegisterException()
    {
    }

    public UserRegisterException(string message) : base(message)
    {
    }

    public UserRegisterException(IdentityResult result) 
        : base(string.Join(", ", result.Errors.Select(e => e.Description))) { }
}