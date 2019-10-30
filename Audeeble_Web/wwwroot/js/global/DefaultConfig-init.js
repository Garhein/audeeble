"use strict";

$(document).ready(function () {

    /**********************************************/
    /** Initialisations au chargement de la page **/
    /**********************************************/

    // Titres des éléments
    AudeebleUI_InitializeTitles("body");


    /*********************************************************************************/
    /** Initialisations lors de la détection de l'insertion d'éléments dans le HTML **/
    /*********************************************************************************/
        
    $(document).bind('DOMNodeInserted', function (e) {

        var cible = e.target;

        if (!$(cible).hasClass("insertedInitialized")) {
            // Titres des éléments
            AudeebleUI_InitializeTitles(cible);

            // Ajout de la classe indiquant que l'élément a été initialisé
            $(cible).addClass("insertedInitialized");
        }
    });
});