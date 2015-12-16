'use strict'
var app = angular.module('com', ['ngRoute']);

app.config(['$routeProvider', function($routeProvider) {
    $routeProvider.
      when('/', {
          templateUrl: GetRoot() +  'Areas/Index/partials',
          controller: 'GreetingController'
      }).
      when('/phones/:phoneId', {
          templateUrl: 'partials/phone-detail.html',
          controller: 'PhoneDetailCtrl'
      }).
      otherwise({
          redirectTo: '/phones'
      });
}]);

var GetRoot = function () {
  var rootPath = "./Client/";
  return function GetRootPath() {
    return rootPath;
  }
}();
 