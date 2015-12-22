app.controller('greetingController', ['$scope','$http', function ($scope,$http) {
    $http({
        method: 'GET',
        url: 'http://secure.pm.com/api'
    }).then(function successCallback(response) {
        $scope.greeting = response.data.Result;
    }, function errorCallback(response) {
        $scope.greeting = "api is not accessible.";
    });
}]);