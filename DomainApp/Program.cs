using System;
using UserService.Domain;
using UserService.ValueObjects;

namespace DomainApp;

public class Program
{
	public static void Main(string[] args)
	{
		try
		{
			var userId = Guid.NewGuid();
			var authUserId = Guid.NewGuid();

			var user = new UserProfile(
				userId,
				authUserId,
				new Username("player1"),
				new DisplayName("Player One"),
				new AvatarUrl("https://example.com/avatar.png"),
				new Bio("Hello, I'm a gamer")
			);

			Console.WriteLine("Created user: " + user.Username);

			user.AddReputation(25);
			Console.WriteLine("Reputation: " + user.Reputation);

			var changed = user.SetGameRank(new GameName("Dota2"), 5);
			Console.WriteLine($"SetGameRank changed: {changed}");

			var teamId = Guid.NewGuid();
			var joined = user.JoinTeam(teamId);
			Console.WriteLine($"Joined team: {joined}");

			var left = user.LeaveTeam(teamId);
			Console.WriteLine($"Left team: {left}");

			Console.WriteLine("Game ranks:");
			foreach (var gr in user.GameRanks)
			{
				Console.WriteLine(gr);
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error: " + ex);
		}
	}
}
