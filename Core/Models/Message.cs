using System.ComponentModel.DataAnnotations;

namespace Core.Models;

public class Message
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Content { get; set; }

    public DateTime DateTime { get; set; } = DateTime.UtcNow;

    public Account Account { get; set; }
}