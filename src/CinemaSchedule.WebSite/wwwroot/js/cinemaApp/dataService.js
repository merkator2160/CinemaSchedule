cinemaApp.factory("dataService", function ($http)
{
	var dataService =
	{
		GetCinemas: function()
		{
			return $http.get("/api/Cinema/GetAllCinemas");
		},
		GetMovies: function()
		{
			return $http.get("/api/Cinema/GetAllMovies");
		},
		GetDates: function()
		{
			return $http.get("/api/Cinema/CreateDatesForEditor");
		},
		GetSessions: function (cinemaId, movieId, date)
		{
			return $http.get("/api/Cinema/GetSessions",
			{
				params: 
				{
					cinemaId: cinemaId,
					movieId: movieId,
					date: date
				}
			});
		},
		GetSessionsWithCinemaAndMovie: function()
		{
			return $http.get("/api/Cinema/GetSessionsWithCinemaAndMovie");
		}
	};

	return dataService;
});