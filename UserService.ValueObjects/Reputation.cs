using UserService.ValueObjects.Base;
using UserService.ValueObjects.Validators;

namespace UserService.ValueObjects;

/// <summary>
/// Represents a user's reputation points as a value object.
/// </summary>
public class Reputation(int points) : ValueObject<int>(new ReputationValidator(), points)
{
    public int Points => Value;

    public override string ToString() => Value.ToString();
}
