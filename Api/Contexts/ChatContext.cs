using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Contexts;

public class ChatContext : DbContext
{
    public DbSet<Account> Accounts { get; set; } = null!;

    public DbSet<Message> Messages { get; set; } = null!;

    public ChatContext(DbContextOptions<ChatContext> options) : base(options){}
}