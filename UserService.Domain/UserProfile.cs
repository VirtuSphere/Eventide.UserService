using UserService.ValueObjects;
using UserService.ValueObjects.Exceptions;
using UserService.Domain.Base;
using UserService.Domain.Exceptions;

namespace UserService.Domain;

public class UserProfile : Entity<Guid>
{
    public Guid AuthUserId { get; private set; }
    public Username Username { get; private set; } = null!;
    public DisplayName DisplayName { get; private set; } = null!;
    public AvatarUrl? AvatarUrl { get; private set; }
    public Bio? Bio { get; private set; }
    public Reputation Reputation { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public List<Guid> TeamIds { get; private set; } = new();
    private readonly List<GameRank> _gameRanks = new();
    public IReadOnlyCollection<GameRank> GameRanks => _gameRanks.AsReadOnly();

    protected UserProfile() { }

    public UserProfile(Guid id,
                       Guid authUserId,
                       Username username,
                       DisplayName displayName,
                       AvatarUrl? avatarUrl = null,
                       Bio? bio = null) : base(id)
    {
        Username = username ?? throw new UsernameNullException(nameof(username), id);
        DisplayName = displayName ?? throw new DisplayNameNullException(nameof(displayName), id);
        AuthUserId = authUserId;
        AvatarUrl = avatarUrl;
        Bio = bio;
        Reputation = new Reputation(0);
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public bool UpdateProfile(DisplayName? displayName, AvatarUrl? avatarUrl, Bio? bio)
    {
        var changed = false;

        if (displayName != null && !displayName.Equals(DisplayName))
        {
            DisplayName = displayName;
            changed = true;
        }

        if (avatarUrl != null && !avatarUrl.Equals(AvatarUrl))
        {
            AvatarUrl = avatarUrl;
            changed = true;
        }

        if (bio != null && !bio.Equals(Bio))
        {
            Bio = bio;
            changed = true;
        }

        if (changed)
            UpdatedAt = DateTime.UtcNow;

        return changed;
    }

    public bool AddReputation(int points)
    {
        if (points <= 0) throw new ArgumentOutOfRangeException(nameof(points), "Reputation points must be positive");
        Reputation = new Reputation(Reputation.Value + points);
        return true;
    }

    public bool SetGameRank(GameName gameName, int rank)
    {
        if (gameName is null) throw new ArgumentNullException(nameof(gameName));
        if (rank < 0) throw new ArgumentOutOfRangeException(nameof(rank));

        var existing = _gameRanks.FindIndex(g => g.Game.Equals(gameName));
        if (existing >= 0)
        {
            var current = _gameRanks[existing];
            if (current.Rank == rank) return false;
            _gameRanks[existing] = new GameRank(gameName, rank);
            return true;
        }

        _gameRanks.Add(new GameRank(gameName, rank));
        return true;
    }

    public bool JoinTeam(Guid teamId)
    {
        if (TeamIds.Contains(teamId)) return false;
        TeamIds.Add(teamId);
        return true;
    }

    public bool LeaveTeam(Guid teamId)
    {
        if (!TeamIds.Contains(teamId)) return false;
        TeamIds.Remove(teamId);
        return true;
    }
}