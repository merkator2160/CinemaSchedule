using CinemaSchedule.Database.Models.Storage;
using MongoDB.Driver;

namespace CinemaSchedule.Database
{
	public static class DataSeeder
	{
		public static void AddInitialData(this DataContext context)
		{
			context.AddCinemas();
		}
		private static void AddCinemas(this DataContext context)
		{
			if(!context.Cinemas.AsQueryable().Any())
			{
				context.Cinemas.InsertMany(new[]
				{
					new CinemaDb()
					{
						Name = "Sun pictures",
						City = "Broome",
						Country = "Australia"
					},
					new CinemaDb()
					{
						Name = "TLC Chinese theater",
						City = "Los angeles",
						Country = "USA"
					},
					new CinemaDb()
					{
						Name = "Colosseum kino",
						City = "Oslo",
						Country = "Norway"
					},
					new CinemaDb()
					{
						Name = "SCI-FI Dine-In theater",
						City = "Walt Disney World",
						Country = "USA"
					},
					new CinemaDb()
					{
						Name = "Rajmandir theater",
						City = "Jaipur",
						Country = "India"
					},
					new CinemaDb()
					{
						Name = "Fox theater",
						City = "Detroit",
						Country = "USA"
					},
					new CinemaDb()
					{
						Name = "Electric cinema",
						City = "London",
						Country = "Great Britain"
					},
					new CinemaDb()
					{
						Name = "Chine de cher",
						City = "Seoul",
						Country = "South korea"
					},
					new CinemaDb()
					{
						Name = "Cinema dei piccoli",
						City = "Rome",
						Country = "Italy"
					},
					new CinemaDb()
					{
						Name = "Cineteca matadero",
						City = "Madrid",
						Country = "Spain"
					}
				});
			}
		}
	}
}