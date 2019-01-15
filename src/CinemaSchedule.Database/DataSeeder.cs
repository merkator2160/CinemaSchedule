using CinemaSchedule.Database.Models.Storage;
using MongoDB.Driver;
using System;

namespace CinemaSchedule.Database
{
	public static class DataSeeder
	{
		public static void AddInitialData(this DataContext context)
		{
			var cinemas = CreateCinemas();
			var movies = CreateMovies();

			context.AddCinemas(cinemas);
			context.AddMovies(movies);
		}

		private static CinemaDb[] CreateCinemas()
		{
			return new[]
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
					Country = "United States"
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
					Country = "United States"
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
					Country = "United States"
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
			};
		}
		private static MovieDb[] CreateMovies()
		{
			return new[]
			{
				new MovieDb()
				{
					Name = "Alita: Battle Angel",
					ReleaseDate = new DateTime(2019, 2, 14),
					Country = "United States",
					Director = "Robert Rodriguez",
					Composer = "Junkie XL",
					Producer = "James Cameron",
					Duration = 122
				},
				new MovieDb()
				{
					Name = "Chappie",
					ReleaseDate = new DateTime(2015, 3, 4),
					Country = "United States",
					Director = "Neill Blomkamp",
					Composer = "Hans Zimmer",
					Producer = "Neill Blomkamp",
					Duration = 120
				},
				new MovieDb()
				{
					Name = "Gremlins",
					ReleaseDate = new DateTime(1984, 6, 8),
					Country = "United States",
					Director = "Joe Dante",
					Composer = "Jerry Goldsmith",
					Producer = "Kathleen Kennedy",
					Duration = 106
				},
				new MovieDb()
				{
					Name = "Pacific Rim",
					ReleaseDate = new DateTime(2013, 7, 12),
					Country = "United States",
					Director ="Guillermo del Toro",
					Composer = "Ramin Djawadi",
					Producer = "Guillermo del Toro",
					Duration = 132
				},
				new MovieDb()
				{
					Name = "Gremlins 2: The New Batch",
					ReleaseDate = new DateTime(1990, 6, 15),
					Country = "United States",
					Director = "Joe Dante",
					Composer = "Rick Baker",
					Producer = "Rick Baker",
					Duration = 106
				},
				new MovieDb()
				{
					Name = "WALL·E",
					ReleaseDate = new DateTime(2008, 6, 21),
					Country = "United States",
					Director = "Andrew Stanton",
					Composer = "Thomas Newman",
					Producer = "Jim Morris",
					Duration = 98
				},
				new MovieDb()
				{
					Name = "I, Robot",
					ReleaseDate = new DateTime(2004, 7, 7),
					Country = "United States",
					Director = "Alex Proyas",
					Composer = "Marco Beltrami",
					Producer = "Michael Lee Baron",
					Duration = 115
				},
				new MovieDb()
				{
					Name = "Ready Player One",
					ReleaseDate = new DateTime(2018, 3, 11),
					Country = "United States",
					Director = "Steven Spielberg",
					Composer = "Alan Silvestri",
					Producer = "Steven Spielberg",
					Duration = 140
				},
				new MovieDb()
				{
					Name = "Avatar",
					ReleaseDate = new DateTime(2009, 12, 10),
					Country = "Great Britain",
					Director = "James Cameron",
					Composer = "James Horner",
					Producer = "James Cameron",
					Duration = 161
				},
				new MovieDb()
				{
					Name = "Intouchables",
					ReleaseDate = new DateTime(2011, 9, 23),
					Country = "France",
					Director = "Olivier Nakache",
					Composer = "Ludovico Einaudi",
					Producer = "Nicolas Duval Adassovsky",
					Duration = 112
				},
				new MovieDb()
				{
					Name = "Terminator 2: Judgment Day",
					ReleaseDate = new DateTime(1991, 7, 1),
					Country = "United States",
					Director = "James Cameron",
					Composer = "Brad Fiedel",
					Producer = "James Cameron",
					Duration = 137
				},
				new MovieDb()
				{
					Name = "Back to the Future",
					ReleaseDate = new DateTime(1985, 7, 3),
					Country = "United States",
					Director = "Robert Zemeckis",
					Composer = "Alan Silvestri",
					Producer = "Neil Canton",
					Duration = 116
				},
				new MovieDb()
				{
					Name = "Kubo and the Two Strings",
					ReleaseDate = new DateTime(2016, 8, 13),
					Country = "United States",
					Director = "Travis Knight",
					Composer = "Dario Marianelli",
					Producer = "Travis Knight",
					Duration = 101
				},
				new MovieDb()
				{
					Name = "Blade Runner",
					ReleaseDate = new DateTime(1982, 6, 25),
					Country = "United States",
					Director = "Ridley Scott",
					Composer = "Vangelis",
					Producer = "Michael Deeley",
					Duration = 117
				},
				new MovieDb()
				{
					Name = "The Dark Knight",
					ReleaseDate = new DateTime(2008, 7, 14),
					Country = "United States",
					Director = "Christopher Nolan",
					Composer = "James Newton Howard",
					Producer = "Christopher Nolan",
					Duration = 152
				},
				new MovieDb()
				{
					Name = "The Addams Family Values",
					ReleaseDate = new DateTime(),
					Country = "United States",
					Director = "Barry Sonnenfeld",
					Composer = "Marc Shaiman",
					Producer = "Scott Rudin",
					Duration = 94
				}
			};
		}
		private static void AddCinemas(this DataContext context, CinemaDb[] cinemas)
		{
			if(!context.Cinemas.AsQueryable().Any())
			{
				context.Cinemas.InsertMany(cinemas);
			}
		}
		private static void AddMovies(this DataContext context, MovieDb[] movies)
		{
			if(!context.Movies.AsQueryable().Any())
			{
				context.Movies.InsertMany(movies);
			}
		}
		private static void AddCinemaMovieRelations(this DataContext context, MovieDb[] movies)
		{
			if(!context.Movies.AsQueryable().Any())
			{
				context.Movies.InsertMany(movies);
			}
		}

	}
}