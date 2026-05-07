using UserService.ValueObjects.Base;
using UserService.ValueObjects.Exceptions;

namespace UserService.ValueObjects.Validators;

public class BioValidator : IValidator<string>
{
    public static int MAX_LENGTH => 500;

    public void Validate(string value)
    {
        if (value is null)
            return; // bio can be optional; null allowed

        if (value.Length > MAX_LENGTH)
            throw new ArgumentLongValueException(nameof(value), value, MAX_LENGTH);
    }
}
