using System;

namespace UserService.ValueObjects.Exceptions;

public class GameRankOutOfRangeException : ArgumentOutOfRangeException
{
    public int ValuePassed { get; }
    public int Min { get; }
    public int Max { get; }

    public GameRankOutOfRangeException(string paramName, int value, int min, int max)
        : base(paramName, $"Game rank {value} is outside allowed range [{min},{max}]")
    {
        ValuePassed = value;
        Min = min;
        Max = max;
    }
}
