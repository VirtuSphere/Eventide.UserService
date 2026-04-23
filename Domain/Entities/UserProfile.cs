using Eventide.UserService.Domain.Enums;
using Eventide.UserService.Domain.Exceptions;
using Eventide.UserService.Domain.ValueObjects;

namespace Eventide.UserService.Domain.Entities;

public class UserProfile
{
    public Guid Id { get; private set; }
    public Guid AuthUserId { get; private set; }
    public string Username { get; private set; }
    public string DisplayName { get; private set; }
    public string? AvatarUrl { get; private set; }
    public string? Bio { get; private set; }
    public int Reputation { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public List<Guid> TeamIds { get; private set; } = new();
    public Dictionary<string, int> GameRanks { get; private set; } = new();

    private UserProfile() { }

    public static UserProfile Create(Guid authUserId, string username, string displayName)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new DomainException("Username cannot be empty");
        if (username.Length < 3)
            throw new DomainException("Username must be at least 3 characters");

        return new UserProfile
        {
            Id = Guid.NewGuid(),
            AuthUserId = authUserId,
            Username = username.ToLower().Trim(),
            DisplayName = displayName.Trim(),
            Reputation = 0,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };
    }

    public void UpdateProfile(string? displayName, string? avatarUrl, string? bio)
    {
        DisplayName = displayName ?? DisplayName;
        AvatarUrl = avatarUrl ?? AvatarUrl;
        Bio = bio ?? Bio;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddReputation(int points)
    {
        if (points <= 0) throw new DomainException("Reputation points must be positive");
        Reputation += points;
    }

    public void SetGameRank(string game, int rank)
    {
        if (string.IsNullOrWhiteSpace(game)) throw new DomainException("Game name cannot be empty");
        if (rank < 0) throw new DomainException("Rank cannot be negative");
        GameRanks[game] = rank;
    }

    public void JoinTeam(Guid teamId)
    {
        if (TeamIds.Contains(teamId)) throw new DomainException("Already in this team");
        TeamIds.Add(teamId);
    }

    public void LeaveTeam(Guid teamId)
    {
        if (!TeamIds.Contains(teamId)) throw new DomainException("Not in this team");
        TeamIds.Remove(teamId);
    }
}