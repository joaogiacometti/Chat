using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class ChatContext : DbContext
{
    public DbSet<Account> Accounts { get; set; } = null!;

    public DbSet<Message> Messages { get; set; } = null!;

    public ChatContext(DbContextOptions<ChatContext> options) : base(options){}
}