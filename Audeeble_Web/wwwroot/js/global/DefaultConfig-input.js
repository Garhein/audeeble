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

/**
 * Initialisation des titres des éléments HTML
 * @author  Xavier VILLEMIN
 * @param   {object} htmlContent Contenu HTML à analyser
 */
function AudeebleUI_InitializeTitles(htmlContent) {

    // Cases à cocher permettant de sélectionner/désélectionner tous les éléments
    AudeebleUI_InitializeCheckBoxAll(htmlContent);

    // Liens et boutons de modification
    $(".ui-link-edit:not([title]), .ui-link-edit[title='']", htmlContent).attr("title", "Éditer");
    $(".ui-btn-edit:not([title]), .ui-btn-edit[title='']", htmlContent).attr("title", "Éditer");
    
    // Liens et boutons de suppression
    $(".ui-link-delete:not([title]), .ui-link-delete[title='']", htmlContent).attr("title", "Supprimer");
    $(".ui-btn-delete:not([title]), .ui-btn-delete[title='']", htmlContent).attr("title", "Supprimer");

    // Liens et boutons de création
    $(".ui-link-add:not([title]), .ui-link-add[title='']", htmlContent).attr("title", "Ajouter");
    $(".ui-btn-add:not([title]), .ui-btn-add[title='']", htmlContent).attr("title", "Ajouter");

    // Liens et boutons d'export PDF
    $(".ui-link-exp-pdf:not([title]), .ui-link-exp-pdf[title='']", htmlContent).attr("title", "Exporter PDF");
    $(".ui-btn-exp-pdf:not([title]), .ui-btn-exp-pdf[title='']", htmlContent).attr("title", "Exporter PDF");

    // Liens et boutons d'export Excel
    $(".ui-link-exp-excel:not([title]), .ui-link-exp-excel[title='']", htmlContent).attr("title", "Exporter Excel");
    $(".ui-btn-exp-excel:not([title]), .ui-btn-exp-excel[title='']", htmlContent).attr("title", "Exporter Excel");
}