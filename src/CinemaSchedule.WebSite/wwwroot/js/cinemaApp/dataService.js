cinemaApp.factory("dataService", function ($http)
{
	var dataService =
	{
		GetCinemas: function()
		{
			return $http.get("/api/Cinema/GetAllCinemas");
		},
		GetMovies: function ()
		{
			return $http.get("/api/Cinema/GetAllMovies");
		},
		GetDates: function ()
		{
			return $http.get("/api/Cinema/CreateDatesForEditor");
		}
	};

	return dataService;
});