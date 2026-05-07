using UserService.ValueObjects.Base;
using UserService.ValueObjects.Validators;

namespace UserService.ValueObjects;

public class Bio(string text) : ValueObject<string>(new BioValidator(), text)
{
}
