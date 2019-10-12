/// <binding ProjectOpened='watch' />

// Chargement des dépendances
var gulp    = require('gulp'),
    sass    = require('gulp-sass'),
    minify  = require('gulp-csso'),
    rename  = require('gulp-rename');

/***************************/
/** Définition des tâches **/
/***************************/

// Tâche de "build"
gulp.task('css', function () {
    return gulp
        .src('./wwwroot/scss/**/*.scss')
        .pipe(sass())
        .pipe(gulp.dest('./wwwroot/css'));
});

// Tâche de "prod" : minification CSS
gulp.task('minify', function () {
    return gulp
        .src('./wwwroot/css/*.css')
        .pipe(minify())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('./wwwroot/css/'));
});

/**********************/
/** Ajout des tâches **/
/**********************/

// Tâche "build"
gulp.task('build', gulp.series('css'));

// Tâche "prod" : Build + minify
gulp.task('prod', gulp.series('build', 'minify'));

// Tâche "watch" : surveillance des fichiers SASS
gulp.task('watch', function () {
    gulp.watch('./wwwroot/scss/**/*.scss', gulp.series('build'));
});

// Tâche par défaut
gulp.task('default', gulp.series('build'));