using System;

namespace UserService.Domain.Exceptions;

public class AlreadyInTeamException : InvalidOperationException
{
    public Guid UserId { get; }
    public Guid TeamId { get; }

    public AlreadyInTeamException(Guid userId, Guid teamId)
        : base($"User {userId} is already a member of team {teamId}.")
    {
        UserId = userId;
        TeamId = teamId;
    }
}
