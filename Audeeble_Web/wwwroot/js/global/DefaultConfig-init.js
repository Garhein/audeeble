"use strict";

$(document).ready(function () {

    /**********************************************/
    /** Initialisations au chargement de la page **/
    /**********************************************/

    // Initialisation des cases à cocher permettant de cocher/décocher tous les éléments
    AudeebleUI_InitializeCheckBoxAll("body");


    /*********************************************************************************/
    /** Initialisations lors de la détection de l'insertion d'éléments dans le HTML **/
    /*********************************************************************************/
        
    $(document).bind('DOMNodeInserted', function (e) {

        var cible = e.target;

        if (!$(cible).hasClass("insertedInitialized")) {
            // Initialisation des cases à cocher permettant de cocher/décocher tous les éléments
            AudeebleUI_InitializeCheckBoxAll(cible);

            // Ajout de la classe indiquant que l'élément a été initialisé
            $(cible).addClass("insertedInitialized");
        }
    });
});