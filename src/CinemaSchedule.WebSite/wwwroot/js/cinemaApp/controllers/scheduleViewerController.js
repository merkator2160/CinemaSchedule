cinemaApp.controller("scheduleViewerController", function ($scope, dataService)
{
	GetData($scope, dataService);
});


// FUNCTIONS //////////////////////////////////////////////////////////////////////////////////////
function GetData($scope, dataService)
{
	dataService.GetSchedule()
		.then(function (value)
		{
			$scope.cinemas = value.data;
		})
		.catch(function (error)
		{
			var message = error.status + " " + error.statusText + "  \"" + error.config.url + "\"";

			$scope.errorMessage = message;
			//console.log(message);
			//alert(message);
		});
}