cinemaApp.controller("scheduleController", function ($scope, dataService)
{
	GetData($scope, dataService);
	InitEvents($scope);
});


// FUNCTIONS //////////////////////////////////////////////////////////////////////////////////////
function GetData($scope, dataService)
{
	var promise = dataService.GetCinemas();
	promise.then(function(value)
	{
		$scope.cinemas = value.data;
		$scope.selectedCinema = $scope.cinemas[0];
	});

	

	//$http.get("/api/Cinema/GetAllCinemas").then(function (result)
 //   {
 //       $scope.Cinemas = result.data;
 //       $scope.selectedCinema = $scope.Cinemas[0];

 //       //return $http.get('');
 //   }).then(function (result)
 //   {
 //       $scope.AvailableFilms = result.data;

 //       InitEvents($scope);
 //   }).catch(function(error)
 //   {
 //       var message = "An error occured: " + error.data.Message;
 //       $log.error(message);
 //       alert(message);
 //   });
}
function InitEvents($scope, $log)
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