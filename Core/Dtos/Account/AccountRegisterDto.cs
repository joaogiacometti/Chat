using System.ComponentModel.DataAnnotations;

namespace Core.Dtos;

public record AccountRegisterDto(
    [Required] string Username,
    [Required] string Email,
    [Required] string Password);