'use strict'
var app = angular.module('com', ['ngRoute', 'ngMessages']);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
      when('/', {
          templateUrl: RootClientUrl + 'Areas/Greeting/partials/greeting.html',
          controller: 'greetingController'
      })
        .when('/signup', {
            templateUrl: RootClientUrl + 'Areas/SignUp/partials/signup.html',
            controller: 'signupController'
        })
        .when('/login', {
            templateUrl: RootClientUrl + 'Areas/Login/partials/login.html',
            controller: 'loginController'
        })
        .otherwise({
            redirectTo: '/'
        });
}]);

