using System;
using UserService.ValueObjects.Base;
using UserService.ValueObjects.Exceptions;

namespace UserService.ValueObjects.Validators;

public class AvatarUrlValidator : IValidator<string>
{
    public static int MAX_LENGTH => 200;

    public void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullOrWhiteSpaceException(nameof(value));

        if (value.Length > MAX_LENGTH)
            throw new ArgumentLongValueException(nameof(value), value, MAX_LENGTH);

        if (!Uri.TryCreate(value, UriKind.Absolute, out var uri))
            throw new FormatException($"AvatarUrl '{value}' is not a valid absolute URL.");
    }
}
