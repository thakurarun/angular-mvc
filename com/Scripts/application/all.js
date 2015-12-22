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
app.controller('loginController', ['$scope', function ($scope) {
    $scope.message = 'login!';

    var login = {
        "firstname": ""
        , "firstname": ""
        , "firstname": ""
    }

}]);
app.controller('menuController', ['$scope', function ($scope) {
    $scope.Menu = [
          { name: "Sign up", link: "#signup" }
        , { name: "Login", link: "#login" }
    ]
}]);
app.controller('signupController', ['$scope', function ($scope) {
    $scope.model = {};
    $scope.isValid = false;
    $scope.submitForm = function () {
        $scope.isValid = true;
        console.log('submit' + $scope.model);
        
    }
}]);
app.directive('textArea', function () {
    var minMessage = '{0} more to go...';
    var maxMessage = '{0} characters left.';
    var defaultMessage = 'enter at least {0} characters';;
    function link(scope, element, attrs) {
        scope.message = defaultMessage.format(scope.min);
        var btn = element.find('a[role=button]');
        element.on('keyup', btn, function (e) {
            var len = $.trim(e.target.value).length;
            var msg = '';
            var left = 0;
            if (len == 0) {
                msg = defaultMessage.format(scope.min);
                btn.hasClass('disabled') ? '' : btn.addClass('disabled');
            } else if (len >= scope.min) {
                left = scope.max - len;
                msg = maxMessage.format(left);
                btn.hasClass('disabled') ? btn.removeClass('disabled') : '';
            } else if (len < scope.min) {
                left = scope.min - len;
                msg = minMessage.format(left);
                btn.hasClass('disabled') ? '' : btn.addClass('disabled');
            }
            scope.$apply(function () {
                scope.message = msg;
            });
        });
    }
    return {
        restrict: 'E',
        replace: true,
        scope: {
            max: '@',
            min: '@',
            message: '@',
            buttonText: '@'
        },
        templateUrl: RootClientUrl + 'CustomControls/TextAreaControl/templateTextArea.html',
        link: link
    };
});

app.directive('textBox', function () {
    var minMessage = '{0} more to go...';
    var maxMessage = '{0} characters left.';
    var defaultMessage = 'enter at least {0} characters';;
    function link(scope, element, attrs) {
        scope.message = defaultMessage.format(scope.min);
        element.on('keyup',  function (e) {
            var len = $.trim(e.target.value).length;
            var msg = '';
            var left = 0;
            if (len == 0) {
                msg = defaultMessage.format(scope.min);
            } else if (len >= scope.min) {
                left = scope.max - len;
                msg = maxMessage.format(left);;
            } else if (len < scope.min) {
                left = scope.min - len;
                msg = minMessage.format(left);
            }
            scope.$apply(function () {
                scope.message = msg;
            });
        });
    }
    return {
        restrict: 'E',
        replace: true,
        scope: {
            max: '@',
            min: '@',
            message: '@'
        },
        templateUrl: RootClientUrl + 'CustomControls/TextBoxControl/templateTextBox.html',
        link: link
    };
});

app.directive("compareTo", function () {
    return {
        require: "ngModel",
        scope: {
            otherModelValue: "=compareTo"
        },
        link: function (scope, element, attributes, ngModel) {

            ngModel.$validators.compareTo = function (modelValue) {
                return modelValue == scope.otherModelValue.$viewValue;
            };

            scope.$watch("otherModelValue", function () {
                ngModel.$validate();
            });
        }
    };
});
// First, checks if it isn't implemented yet.
if (!String.prototype.format) {
    String.prototype.format = function () {
        var args = arguments;
        return this.replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] != 'undefined'
              ? args[number]
              : match
            ;
        });
    };
}
var RootClientUrl = function () {
    var rootPath = "./Client/";
    return rootPath;
}();
