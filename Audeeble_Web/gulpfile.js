/// <binding ProjectOpened='watch' />

// Chargement des dépendances
var gulp = require('gulp'),
    sass = require('gulp-sass');

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
/*
gulp.task('minify', function () {
    return gulp
        .src('./wwwroot/css/*.css')
        .pipe(plugins.csso())
        .pipe(plugins.rename({ suffix: '.min' }))
        .pipe(gulp.dest('./wwwroot/css/'));
});
*/

/**********************/
/** Ajout des tâches **/
/**********************/

// Tâche "build"
gulp.task('build', gulp.parallel('css'));

// Tâche "prod" : Build + minify
// gulp.task('prod', gulp.parallel('build', 'minify'));

// Tâche "watch" : surveillance des fichiers SASS
gulp.task('watch', function () {
    gulp.watch('./wwwroot/scss/**/*.scss', gulp.parallel('build'));
});

// Tâche par défaut
gulp.task('default', gulp.parallel('build'));