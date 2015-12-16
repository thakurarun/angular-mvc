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
        scope: {
            max: '@',
            min: '@',
            message: '@',
            buttonText: '@'
        },
        templateUrl: GetRoot() + 'CustomControls/TextAreaControl/templateTextArea.html',
        link: link
    };
});
