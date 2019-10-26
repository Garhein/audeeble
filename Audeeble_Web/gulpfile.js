/// <binding ProjectOpened='watch' />

// Chargement des dépendances
var gulp    = require('gulp'),
    sass    = require('gulp-sass');

/***********************************************************************/
/** Définition de la tâche de transformation des fichiers SASS en CSS **/
/***********************************************************************/

// Tâche de "build" 
gulp.task('css', function () {
    return gulp
        .src('./wwwroot/scss/**/*.scss')
        .pipe(sass())
        .pipe(gulp.dest('./wwwroot/css'));
});

/**********************/
/** Ajout des tâches **/
/**********************/

// Tâche "watch" : surveillance des fichiers SASS
gulp.task('watch', function () {
    gulp.watch('./wwwroot/scss/**/*.scss', gulp.series('css'));
});

// Tâche par défaut
gulp.task('default', gulp.series('css'));