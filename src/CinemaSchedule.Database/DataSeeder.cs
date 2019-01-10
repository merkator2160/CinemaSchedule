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
			context.Cinemas.FindOneAndReplaceAsync(p => p.Name.Equals("Sun pictures"), new CinemaDb()
			{
				Name = "Sun pictures",
				City = "Broome",
				Country = "Australia"
			});
			context.Cinemas.FindOneAndReplaceAsync(p => p.Name.Equals("TLC Chinese theater"), new CinemaDb()
			{
				Name = "TLC Chinese theater",
				City = "Los angeles",
				Country = "USA"
			});
			context.Cinemas.FindOneAndReplaceAsync(p => p.Name.Equals("Colosseum kino"), new CinemaDb()
			{
				Name = "Colosseum kino",
				City = "Oslo",
				Country = "Norway"
			});
			context.Cinemas.FindOneAndReplaceAsync(p => p.Name.Equals("SCI-FI Dine-In theater"), new CinemaDb()
			{
				Name = "SCI-FI Dine-In theater",
				City = "Walt Disney World",
				Country = "USA"
			});
			context.Cinemas.FindOneAndReplaceAsync(p => p.Name.Equals("Rajmandir theater"), new CinemaDb()
			{
				Name = "Rajmandir theater",
				City = "Jaipur",
				Country = "India"
			});
			context.Cinemas.FindOneAndReplaceAsync(p => p.Name.Equals("Fox theater"), new CinemaDb()
			{
				Name = "Fox theater",
				City = "Detroit",
				Country = "USA"
			});
			context.Cinemas.FindOneAndReplaceAsync(p => p.Name.Equals("Electric cinema"), new CinemaDb()
			{
				Name = "Electric cinema",
				City = "London",
				Country = "Great Britain"
			});
			context.Cinemas.FindOneAndReplaceAsync(p => p.Name.Equals("Chine de cher"), new CinemaDb()
			{
				Name = "Chine de cher",
				City = "Seoul",
				Country = "South korea"
			});
			context.Cinemas.FindOneAndReplaceAsync(p => p.Name.Equals("Cinema dei piccoli"), new CinemaDb()
			{
				Name = "Cinema dei piccoli",
				City = "Rome",
				Country = "Italy"
			});
			context.Cinemas.FindOneAndReplaceAsync(p => p.Name.Equals("Cineteca matadero"), new CinemaDb()
			{
				Name = "Cineteca matadero",
				City = "Madrid",
				Country = "Spain"
			});
		}
	}
}