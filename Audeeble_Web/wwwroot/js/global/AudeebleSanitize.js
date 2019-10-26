"use strict";

/**
 * Parcours d'un objet JSON pour évaluer les dates restées en string "/Date(timestamp)/"
 * Toutes les propriétés de l'objet sont parcourues pour écrire les dates manquantes
 * @param  {object}  object Objet JSON à évaluer
 * @return {object}         Objet JSON modifié   
 */
function AudeebleSanitize_JsonObjectDates(object) {
    for (var key in object) {
        // Regex de recherche des dates
        var regexDate = /\/(Date\(-?\d+\))\//g;

        // Si la clé est définie et que sa valeur n'est pas nulle
        if (key !== null && key !== undefined && object[key] !== null && object[key] !== undefined) {
            var content = object[key];

            // La valeur est un objet => on exécute le parcours de cet objet
            if (typeof content === "object") {
                object[key] = AudeebleSanitize_JsonObjectDates(object[key]);
            }
            // La valeur est un string et elle contient un champ date correspondant au regex
            else if (typeof content === "string" && regexDate.test(content)) {
                var strDate = content.replace(regexDate, 'new $1');
                object[key] = eval(strDate);
            }
        }
    }

    return object;
}