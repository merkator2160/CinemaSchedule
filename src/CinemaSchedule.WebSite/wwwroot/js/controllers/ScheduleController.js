angular.module("CinemaApp").controller("ScheduleController", function ($scope, $http)
{
    getData($scope, $http, $log);
	InitEvents($scope);
});


// FUNCTIONS //////////////////////////////////////////////////////////////////////////////////////
function getData($scope, $http, $log)
{
    $http.get(config.GetAllCinemasUrl).then(function(result)
    {
        $scope.Cinemas = result.data;
        $scope.SelectedCinema = $scope.Cinemas[0];

        return $http.get(config.GetAllFilmsUrl);
    }).then(function (result)
    {
        $scope.AvalibleFilms = result.data;

        InitEvents($scope);
    }).catch(function(error)
    {
        var message = "An error occured: " + error.data.Message;
        $log.error(message);
        alert(message);
    });
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
	$scope.OnOnCinemaChange = function()
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
		console.log("fdfzdfhdf");
	};
}