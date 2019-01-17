/// <binding BeforeBuild='concat' Clean='clean' />
"use strict";

var gulp = require("gulp"),
	rimraf = require("rimraf"),
	concat = require("gulp-concat"),
	cssmin = require("gulp-cssmin"),
	uglify = require("gulp-uglify");

var paths =
{
	libs:
	{
		js:
		[
			"./node_modules/angular/angular.js",
			"./node_modules/jquery/dist/jquery.js",
			"./node_modules/bootstrap/dist/js/bootstrap.bundle.js",
			"./node_modules/jquery-validation/dist/jquery.validate.js",
			"./node_modules/jquery-validation/dist/additional-methods.js",
			"./node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.js",
			"./node_modules/jquery-validation-unobtrusive-bootstrap/dist/unobtrusive-bootstrap.js"
		],
		css:
		[
			"./node_modules/bootstrap/dist/css/bootstrap.min.css",
			"./node_modules/bootstrap/dist/css/bootstrap-grid.css",
			"./node_modules/bootstrap/dist/css/bootstrap-reboot.css"
		]
	},

	concatJsLibDest: "./wwwroot/js/lib.js",
	concatCssLibDest: "./wwwroot/css/lib.css"
};

gulp.task("clean:js", function (cb)
{
	rimraf(paths.concatJsLibDest, cb);
});

gulp.task("clean:css", function (cb)
{
	rimraf(paths.concatCssLibDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);


gulp.task("concat:js", function ()
{
	return gulp
		.src(paths.libs.js)
		.pipe(concat(paths.concatJsLibDest))
		.pipe(gulp.dest(""));
});

gulp.task("concat:css", function ()
{
	return gulp
		.src(paths.libs.css)
		.pipe(concat(paths.concatCssLibDest))
		.pipe(gulp.dest(""));
});

gulp.task("concat", ["concat:js", "concat:css"]);