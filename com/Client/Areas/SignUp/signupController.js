app.controller('signupController', ['$scope', function ($scope) {
    $scope.model = {};
    $scope.submitForm = function () {
        console.log('submit' + $scope.model);
    }
}]);