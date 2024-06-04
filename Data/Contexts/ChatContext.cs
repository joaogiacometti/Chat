using Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class ChatContext(DbContextOptions<ChatContext> options) : IdentityDbContext<User>(options)
{
    private DbSet<Message> Messages { get; set; }
}