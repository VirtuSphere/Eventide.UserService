using UserService.ValueObjects.Base;
using UserService.ValueObjects.Validators;

namespace UserService.ValueObjects;

public class AvatarUrl(string url) : ValueObject<string>(new AvatarUrlValidator(), url)
{
}
