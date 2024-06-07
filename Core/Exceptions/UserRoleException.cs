using Microsoft.AspNetCore.Identity;

namespace Core.Exceptions;

public class UserRoleException : Exception
{
    public UserRoleException()
    {
    }

    public UserRoleException(string message) : base(message)
    {
    }

    public UserRoleException(IdentityResult result) 
        : base(string.Join(", ", result.Errors.Select(e => e.Description))) { }
}