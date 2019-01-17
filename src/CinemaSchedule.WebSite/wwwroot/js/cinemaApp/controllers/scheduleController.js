cinemaApp.controller("scheduleController", function ($scope, dataService)
{
	GetData($scope, dataService);
	InitEvents($scope);
});


// FUNCTIONS //////////////////////////////////////////////////////////////////////////////////////
function GetData($scope, dataService)
{
	dataService.GetCinemas().then(function(value)
	{
		$scope.cinemas = value.data;
		$scope.selectedCinema = $scope.cinemas[0];

		return dataService.GetMovies();
	}).then(function (value)
	{
		$scope.movies = value.data;
		$scope.selectedMovie = $scope.movies[0];
	}).catch(function (error)
	{
		var message = error.status + " " + error.statusText + "  \"" + error.config.url + "\"";

		$scope.errorMessage = message;
		//console.log(message);
		//alert(message);
	});
}
function InitEvents($scope)
{
	$scope.OnOkBtnClick = function()
	{
	};
	$scope.OnCancelBtnClick = function()
	{
	};
	$scope.OnRemoveBtnClick = function()
	{
	};
	$scope.OnOnFilmChange = function()
	{
	};
	$scope.OnDateChange = function()
	{
	};
	$scope.OnTestBtnClick = function()
	{
		console.log($scope.selectedCinema.name);
	};
}