using UserService.ValueObjects.Validators;
using UserService.ValueObjects.Exceptions;

namespace UserService.ValueObjects;

/// <summary>
/// Represents a game and the user's rank in it. Validated on construction.
/// </summary>
public sealed class GameRank : IEquatable<GameRank>
{
	public GameName Game { get; }
	public int Rank { get; }

	public GameRank(GameName game, int rank)
	{
		Game = game ?? throw new ArgumentNullException(nameof(game));
		if (rank < 0) throw new GameRankOutOfRangeException(nameof(rank), rank, 0, int.MaxValue);
		Rank = rank;
	}

	public bool Equals(GameRank? other)
	{
		if (other is null) return false;
		if (ReferenceEquals(this, other)) return true;
		return Game.Equals(other.Game) && Rank == other.Rank;
	}

	public override bool Equals(object? obj) => Equals(obj as GameRank);
	public override int GetHashCode() => HashCode.Combine(Game, Rank);
	public override string ToString() => $"{Game}: {Rank}";
}
