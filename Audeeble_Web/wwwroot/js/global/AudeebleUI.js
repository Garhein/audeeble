"use strict";

/**
 * Modification du titre de la checkbox permettant de cocher/décocher tous les éléments.
 * @author  Xavier VILLEMIN
 * @param   {object}    objCheckBox
 * @param   {boolean}   isCheck
 */
function AudeebleUI_ChangeTitleCheckBoxAll(objCheckBox, isCheck) {
    if ($(objCheckBox).length > 0) {
        if (isCheck) {
            $(objCheckBox).attr("title", "Désélectionner tous les éléments");
        }
        else {
            $(objCheckBox).attr("title", "Sélectionner tous les éléments");
        }
    }
}

//#region Tables

/**
 * Cocher/décocher toutes les checkbox présentes dans la table associée.
 * Seules les checkbox situées dans les colonnes de classe "ui-col-check" sont impactées.
 * @author  Xavier VILLEMIN
 * @param   {object} objClick
 */
function AudeebleUI_TableCheckUncheckAll(objClick) {
    // Récupération de la table
    var tbl = $(objClick).closest("table");

    if (tbl !== null && tbl !== undefined && tbl.length > 0) {

        // Récupération de l'état
        var isChecked = $(objClick).is(":checked");

        // Mise à jour de la bulle d'aide
        // TODO: comment l'initialiser automatiquement à l'affichage (même après Ajax) ?
        AudeebleUI_ChangeTitleCheckBoxAll(objClick, isChecked);

        // Mise à jour des cases à cocher positionnées sur chaque ligne
        $("tbody tr td.ui-col-check input[type=checkbox]", $(tbl)).prop("checked", isChecked);
    }
}

/**
 * Cocher/déocher la checkbox principale au changement d'état d'une checkbox fille.
 * Seules les checkbox situées dans les colonnes de classe "ui-col-check" sont prises en compte.
 * @author  Xavier VILLEMIN
 * @param   {object} objClick
 */
function AudeebleUI_TableCheckUncheckValue(objClick) {
    // Récupération de la table
    var tbl = $(objClick).closest("table");

    if (tbl !== null && tbl !== undefined && tbl.length > 0) {

        // Sélecteur pour la mise à jour du titre de la case à cocher principale
        var checkAll = $("thead tr th.ui-col-check input[type=checkbox]", $(tbl));

        // Nombre de cases à cocher
        var nbCheckBox = $("tbody tr td.ui-col-check input[type=checkbox]", $(tbl)).length;

        // Nombre de cases cochées
        var nbChecked = $("tbody tr td.ui-col-check input[type=checkbox]:checked", $(tbl)).length;

        if (nbChecked == nbCheckBox) {
            $(checkAll).prop("checked", true);
            AudeebleUI_ChangeTitleCheckBoxAll(checkAll, true);
        }
        else {
            $(checkAll).prop("checked", false);
            AudeebleUI_ChangeTitleCheckBoxAll(checkAll, false);
        }
    }
}

//#endregion

//#region Message d'attente

/**
 * Affichage d'un message d'attente.
 * @author  Xavier VILLEMIN
 * @param   {string}    waitingMessage
 */
function AudeebleUI_DisplayWaitingMessage(waitingMessage) {
    // Définition des ID
    var waitingID = "#ui-waiting";
    var messageID = "#ui-waiting-msg";

    // Définition du message
    waitingMessage = (waitingMessage === null || waitingMessage === undefined) ? "Traitement en cours ..." : waitingMessage;

    // Insertion du message
    $(messageID + " span").html(waitingMessage);

    // Ajout de la classe d'animation
    $(messageID + " i").addClass("fa-spin");

    // Affichage du message
    $(waitingID).fadeIn("slow");
}

/**
 * Cacher le message d'attente.
 * @author  Xavier VILLEMIN
 */
function AudeebleUI_HideWaitingMessage() {
    // Définition des ID
    var waitingID = "#ui-waiting";
    var messageID = "#ui-waiting-msg";

    // Retrait de la classe d'animation (économisation des ressources)
    $(messageID + " i").removeClass("fa-spin");

    // Cacher le message
    $(waitingID).fadeOut("slow");
}

//#endregion