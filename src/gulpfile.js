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
    scripts: "./Scripts/",
    styles: "./Styles/",
    lib: "./wwwroot/lib/",
    bower: "./bower_components/"
};

gulp.task("copy-libs", function () {
    var bower_libs = {
        "bootstrap": "bootstrap/dist/**/*.{css,eot,js,map,svg,ttf,woff,woff2}",
        "bootstrap-treeview": "bootstrap-treeview/dist/**/*.{css,js}",
        "jquery": "jquery/dist/**/*.{js,map}",
        "knockout": "knockout/dist/**/*.js",
        "knockout-mapping": "knockout-mapping/*.js"
    };
    for (var lib in bower_libs) {
        gulp.src(paths.bower + bower_libs[lib])
            .pipe(gulp.dest(paths.lib + lib));
    }
});

gulp.task("copy-js", function () {
    return gulp
        .src(paths.scripts + "**/*.js")
        .pipe(gulp.dest(paths.js));
});

gulp.task("less", function () {
    return gulp
        .src(paths.styles + "**/*.less")
        .pipe(gulp_less())
        .pipe(gulp.dest(paths.css));
});

gulp.task("copy-css", ["less"], function () {
    return gulp
        .src([paths.css + "**/*.css", "!" + paths.css + "**/*.min.css"])
        .pipe(gulp_cssmin())
        .pipe(gulp_rename({ suffix: ".min" }))
        .pipe(gulp.dest(paths.css));
});

gulp.task("build", ["copy-libs", "copy-js", "copy-css"])