var uglify = require('gulp-uglify')
    , gp_concat = require('gulp-concat')
    //, debug = require('gulp-debug')
    , readScripts = require('./ReadScripts');

module.exports = function (gulp) {
    gulp.task('compress', function () {
        var paths = ['../Client/app.js'];
        readScripts(paths);
        return gulp.src(paths)
          .pipe(gp_concat('all.js'))
          //.pipe(debug())
          .pipe(gulp.dest('../Scripts/application'));
    });
}
