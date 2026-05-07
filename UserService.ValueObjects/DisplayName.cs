using UserService.ValueObjects.Base;
using UserService.ValueObjects.Validators;

namespace UserService.ValueObjects;

/// <summary>
/// Represents a display name value object.
/// </summary>
public class DisplayName(string name) : ValueObject<string>(new DisplayNameValidator(), name)
{
}
