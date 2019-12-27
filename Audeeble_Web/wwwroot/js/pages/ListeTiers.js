

function ListeTiers_SearchBtnClick() {
    "use strict";

    ajax.ajax({
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: $("#filter-box-liste-tiers :input").serialize(),        
        url: "Tiers/Rechercher",
        dataNonStringify: true,
        dataType: "html",
        success: function (res) {
            $("#div-liste-tiers").html(res);
        }
    });

    /*
    $.ajax({
        contentType: "application/x-www-form-urlencoded; charset=UTF-8",
        data: $("#filter-box-liste-tiers :input").serialize(),
        url: "Tiers/Rechercher",
        timeout: 30000,
        dataType: "html",
        method: "POST",
        beforeSend: function () {
            AudeebleUI_DisplayWaitingMessage();

            // TODO: afficher un indicateur graphique qu'une requête Ajax est en cours
            // TODO: log du démarrage (date, heure, URL de départ, URL demandée, data, GET/POST)
            console.log("Start Ajax request !");
        },
        success: function (res) {
            $("#div-liste-tiers").html(res);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            // TODO: log de l'erreur ?
            // date, heure, URL de départ, URL demandée, data, GET/POST, message de l'erreur
            console.log("Ajax request in error with '" + textStatus + "' status (" + errorThrown + ") !");
        },
        complete: function (jqXHR, textStatus) {
            AudeebleUI_HideWaitingMessage();

            // TODO: retirer l'indicateur graphique qu'une requête Ajax est en cours
            // TODO: log de fin (date, heure, URL de départ, URL demandée, data, GET/POST, erreur)
            console.log("Ajax request completed with '" + textStatus + "' status !");
        }
    });
    */
}


function TestAjax() {
    "use strict";

    ajax.ajax({
        url: "Tiers/AjaxRequest",
        type: "GET",
        timeout: 5000,
        success: function (res) {
            console.log(res.erreur);
            console.log(res.erreurBloquante);
            console.log(res.messageErreur);
            console.log(res.listeErreurs);

            console.log(res.valeursRetour.ajaxBool);
            console.log(res.valeursRetour.ajaxString);
            console.log(res.valeursRetour.ajaxDate);
            console.log(res.valeursRetour.ajaxStrDate);
        }
    });
}