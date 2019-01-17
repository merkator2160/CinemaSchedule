cinemaApp.factory("dataService", function($http, $q)
{
	var dataService =
	{
		GetCinemas: function()
		{
			var deferred = $q.defer();

			$http.get("/api/Cinema/GetAllCinemas").then(function(result)
			{
				deferred.resolve(result);
			}).catch(function(error)
			{
				deferred.reject(error.status);
			});
			return deferred.promise;
		}
	};

	return dataService;
});