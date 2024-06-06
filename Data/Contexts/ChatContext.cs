using Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class ChatContext(DbContextOptions<ChatContext> options) : IdentityDbContext<User, Role, string>(options)
{
    public DbSet<Message> Messages { get; set; }
    
    public DbSet<Chat> Chats { get; set; }
}