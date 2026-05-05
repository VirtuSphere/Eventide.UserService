namespace Eventide.UserService.Application.DTOs;

public class UserProfileDto
{
    public Guid Id { get; init; }
    public Guid AuthUserId { get; init; }
    public string Username { get; init; } = string.Empty;
    public string DisplayName { get; init; } = string.Empty;
    public string? AvatarUrl { get; init; }
    public string? Bio { get; init; }
    public int Reputation { get; init; }
    public Dictionary<string, int> GameRanks { get; init; } = new();
}