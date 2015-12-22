app.controller('signupController', ['$scope', function ($scope) {
    $scope.model = {};
    $scope.isValid = false;
    $scope.submitForm = function () {
        $scope.isValid = true;
        console.log('submit' + $scope.model);
        
    }
}]);