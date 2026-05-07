using System;

namespace UserService.ValueObjects.Exceptions;

public class ReputationOutOfRangeException : ArgumentOutOfRangeException
{
    public int ValuePassed { get; }
    public int Min { get; }
    public int Max { get; }

    public ReputationOutOfRangeException(string paramName, int value, int min, int max)
        : base(paramName, $"Reputation {value} is outside allowed range [{min},{max}]")
    {
        ValuePassed = value;
        Min = min;
        Max = max;
    }
}
