var gulp = require("gulp"),
  fs = require("fs"),
  less = require("gulp-less"),
  sass = require("gulp-sass");

// other content removed

gulp.task("sass", function () {
  return gulp.src("./Styles/root.scss")
    .pipe(sass().on('error', sass.logError))
    .pipe(gulp.dest('./wwwroot/css'));
});

gulp.task('fonts', function() {
  return gulp.src('./node_modules/font-awesome/fonts/*')
    .pipe(gulp.dest('./wwwroot/fonts'))
});

gulp.task('default', ['sass', 'fonts'], function() {
});