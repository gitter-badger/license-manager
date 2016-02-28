var gulp = require("gulp");
var gulp_concat = require("gulp-concat");
var gulp_cssmin = require("gulp-cssmin");
var gulp_less = require("gulp-less");
var gulp_rename = require("gulp-rename");
var gulp_uglify = require("gulp-uglify");
var rimraf = require("rimraf");

var paths = {
    webroot: "./wwwroot/",
    css: "./wwwroot/css/",
    js: "./wwwroot/js/",
    less: "./Styles/"
};

gulp.task("less", function () {
    return gulp
        .src(paths.less + "*.less")
        .pipe(gulp_less())
        .pipe(gulp.dest(paths.css));
});

gulp.task("min:css", ["less"], function () {
    return gulp
        .src([paths.css + "*.css", "!" + paths.css + "*.min.css"])
        .pipe(gulp_cssmin())
        .pipe(gulp_rename( { suffix: ".min" }))
        .pipe(gulp.dest(paths.css));
});

gulp.task("css", ["min:css"])