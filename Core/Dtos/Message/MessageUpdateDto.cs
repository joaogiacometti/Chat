using System.ComponentModel.DataAnnotations;

namespace Core.Dtos;

public record MessageUpdateDto(
    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Invalid id")]
    string Id,
    [Required]
    [StringLength(500, MinimumLength = 1, ErrorMessage = "Content must be between 1 and 500")]
    string Content
);