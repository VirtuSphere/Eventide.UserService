using UserService.ValueObjects.Base;
using UserService.ValueObjects.Validators;

namespace UserService.ValueObjects;

/// <summary>
/// Value object for a game's name.
/// </summary>
public class GameName(string name) : ValueObject<string>(new GameNameValidator(), name)
{
}
