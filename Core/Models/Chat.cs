using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class Chat
{
    [Key] [MaxLength(50)] public required string Id { get; set; }
    
    [MaxLength(100)] public required string Title { get; set; }
    
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    
    public User? User { get; init; }
    
    public string? UserId { get; init; }
}