using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class Message
{
    [Key] [MaxLength(50)] public required string Id { get; set; }

    [MaxLength(500)] public required string Content { get; set; }

    public DateTime DateTime { get; init; } = DateTime.UtcNow;

    public User? User { get; init; }
    
    public required string UserId { get; init; }
}