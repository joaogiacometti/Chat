using System.ComponentModel.DataAnnotations;

namespace Core.Dtos;

public record MessageDto(
    string? Id,
    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Invalid id")]
    string UserId,
    [Required]
    [StringLength(500, MinimumLength = 1, ErrorMessage = "Content must be between 1 and 500")]
    string Content
);