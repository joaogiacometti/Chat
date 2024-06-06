using System.ComponentModel.DataAnnotations;

namespace Core.Dtos;

public record MessageDto(
    string Id,
    string UserId,
    string ChatId,
    string Content
);