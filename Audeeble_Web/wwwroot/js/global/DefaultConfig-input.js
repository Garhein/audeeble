"use strict";

/**
 * Initialisation du titre des cases à cocher permettant de sélectionner/désélectionner tous les éléments
 * @author  Xavier VILLEMIN
 * @param   {object} htmlContent Contenu HTML à analyser
 */
function AudeebleUI_InitializeCheckBoxAll (htmlContent) {
    // Cases cochées
    if ($("thead tr th.ui-col-check input[type=checkbox]:checked", htmlContent).length > 0) {
        $("thead tr th.ui-col-check input[type=checkbox]:checked", htmlContent).prop("title", "Désélectionner tous les éléments");
    }

    // Cases non cochées
    if ($("thead tr th.ui-col-check input[type=checkbox]:not(:checked)", htmlContent).length > 0) {
        $("thead tr th.ui-col-check input[type=checkbox]:not(:checked)", htmlContent).prop("title", "Sélectionner tous les éléments");
    }
}