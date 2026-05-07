using UserService.ValueObjects.Base;
using UserService.ValueObjects.Exceptions;

namespace UserService.ValueObjects.Validators;

public class ReputationValidator : IValidator<int>
{
    public static int MIN => 0;
    public static int MAX => 1_000_000;

    public void Validate(int value)
    {
        if (value < MIN || value > MAX)
            throw new ReputationOutOfRangeException(nameof(value), value, MIN, MAX);
    }
}
