namespace Core.Dtos;

public record AccountUpdateDto(
    string? Username,
    string? Email,
    string? Password);