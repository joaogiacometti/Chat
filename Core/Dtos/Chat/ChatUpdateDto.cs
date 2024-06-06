using System.ComponentModel.DataAnnotations;

namespace Core.Dtos;

public record ChatUpdateDto(
    [Required]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "Invalid id")]
    string Id,
    [Required]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 100 characters")]
    string Title
);