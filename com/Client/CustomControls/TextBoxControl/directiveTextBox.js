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
