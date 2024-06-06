using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models;

public class Message
{
    [Key] [MaxLength(50)] public required string Id { get; set; }

    [MaxLength(500)] public required string Content { get; set; }

    public DateTime DateTime { get; init; } = DateTime.UtcNow;

    [ForeignKey("UserId")]
    public User? User { get; init; }
    
    public string? UserId { get; init; }
    
    [ForeignKey("ChatId")]
    public Chat? Chat { get; init; }
    
    public string? ChatId { get; init; }
}