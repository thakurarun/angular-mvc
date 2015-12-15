var gulp = require('gulp');
var compress = require('./compress')(gulp);
gulp.task('default', ['compress'], function () {
    //console.log('Gulp task running...');
});