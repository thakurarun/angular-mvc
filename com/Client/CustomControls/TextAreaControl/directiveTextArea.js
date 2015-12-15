var app = angular.module('com', []);
app.directive('textArea', function () {
    var minMessage = ' more to go...';
    var maxMessage = ' characters left';
    var defaultMessage = '';
    function link(scope, element, attrs) {
        var defaultMessage = 'enter at least ' + scope.min + ' characters';
        scope.message = defaultMessage;
        element.on('keyup', function (e) {
            var text = $.trim(e.target.value);
            var msg = '';
            if (text.length == 0) {
                msg = defaultMessage;
            } else if (text.length >= scope.min) {
                msg = maxMessage;
            } else if (text.length < scope.min) {
                msg  = minMessage;
            }
            scope.$apply(function () {
                scope.message = msg;
            });
        });
    }
    return {
        restrict: 'E',
        scope: {
            max: '@',
            min: '@',
            message: '@',
        },
        templateUrl: GetRoot() + 'CustomControls/TextAreaControl/templateTextArea.html',
        link: link
    };
});
