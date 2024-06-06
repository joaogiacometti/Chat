namespace Core.Dtos;

public record ChatDto(
    string Id,
    string Title,
    DateTime CreatedAt,
    string UserId
);