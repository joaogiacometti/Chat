using System.ComponentModel.DataAnnotations;

namespace Core.Dtos;

public record MessageCreateDto(
    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Invalid id")]
    string UserId,
    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Invalid id")]
    string ChatId,
    [Required]
    [StringLength(500, MinimumLength = 1, ErrorMessage = "Content must be between 1 and 500 characters")]
    string Content
);