"use strict";

/**
 * Surcharge de l'objet Ajax
 * @author  Xavier VILLEMIN
 * @return  {Object|String} Résultat de l'appel Ajax dans ajax.resultat
 */
var ajax = {    
    // Variable contenant le résultat d'une requête Ajax
    resultat:           "",
    xhr:                null,
    erreur:             false,
    erreurNonBloquante: false,
    messageErreur:      "",

    // Paramètres par défaut des requêtes Ajax
    params: {
        contentType: "application/json; charset=utf-8",        
        affMessageAttente: true,            // Pour afficher le message d'attente au début d'une requête Ajax    
        dataNonStringify: false,            // Conversion d'une valeur JavaScript en chaîne JSON                    
        dataType: "json",                   // Type de données attendu en retour        
        beforeSend: null,                   // Traitements effectuées avant l'envoi d'une requête Ajax        
        timeout: 60000,                     // Timeout par défaut de 60 secondes        
        complete: null,                     // Traitements effectuées à la fin d'une requête Ajax        
        success: null,                      // Traitements effectuées quand la requête Ajax ne génère pas d'erreurs        
        type: "POST",                       // Type de la méthode de la requête Ajax        
        error: null,                        // Traitements effectuées en cas d'erreurs durant la requête Ajax        
        async: true,                        // Les requêtes Ajax sont asynchrones        
        data: {}                            // Données de la requête Ajax
    },

    /**
     * Possibilité d'ajouter de nouveaux paramètres
     * @param {object} obj
     */
    addParams: function (obj) {
        // Tester si l'objet utilisé par la requête est présent et correct
        if (typeof obj !== 'object') {
            this.messageErreur = 'Le moteur Ajax prend uniquement des objets JavaScript en paramètre.';
            return -1;
        }

        ajax.params = $.extend(ajax.params, obj);
    },

    /**
     * Le moteur Ajax prend en paramètre un objet avec différents paramètres
     * qui vont surcharger les paramètres par défaut
     * @param {object} obj
     */
    ajax: function (obj) {
        // Tester si l'objet utilisé par la requête est présent et correct
        if (typeof obj !== 'object') {
            this.messageErreur = 'Le moteur Ajax prend uniquement des objets JavaScript en paramètre.';
            this.erreur = true;
            return -1;
        }

        // Lancement de la requête Ajax
        this.callAjaxRequest(obj);
    },

    /**
     * Appel au lancement de la requête Ajax
     * @param {object} obj
     */
    callAjaxRequest: function (obj) {
        // Merge des paramètres reçus avec ceux par défaut
        // Réinitialisation de la variable stockant le retour d'une requête Ajax
        ajax.resultat = '';
        var req       = {};
        $.extend(req, ajax.params, obj);

        // Exécution de la requête Ajax
        this.execAjaxRequest(req);
        return this.xhr;
    },

    /**
     * Exécution de la requête Ajax
     * @param {any} req
     */
    execAjaxRequest: function (req) {
        // Gestion des données
        var data = req.data;
        if (!req.dataNonStringify) data = JSON.stringify(data);

        this.xhr = $.ajax({                        
            contentType: req.contentType,
            dataType: req.dataType,
            timeout: req.timeout,
            async: req.async,
            type: req.type,
            url: req.url,
            data: data,
            beforeSend: function (jqXHR, settings) {
                // Affichage du message d'attente
                if (req.affMessageAttente) {
                    // TODO
                }

                // Si une fonction doit être exécutée avant l'envoi
                var resBeforeSend;
                
                if (req.beforeSend) {
                    resBeforeSend = req.beforeSend(jqXHR, settings);
                }

                return (resBeforeSend !== null && resBeforeSend !== undefined) ? resBeforeSend : true;
            },
            success: function (data, textStatus, jqXHR) {
                var response = data;
                var isHtml   = false;

                // Réception d'un objet Ajax sérialisé alors qu'une vue HTML est attendue
                if (response !== null && typeof response === "string" && response.indexOf("ListeErreurs") > 0 && response.indexOf("ValeursRetour") > 0) {
                    response = JSON.parse(response);
                    req.dataType = "json";
                    isHtml = true;
                }

                // Traitement sur le JSON
                if (response !== null && req.dataType !== "html") {
                    // Correction de la déclaration des dates en JSON pour une meilleure lecture en JavaScript
                    var regexDate = /"\\\/(Date\(-?\d+\))\\\/"/g;

                    if (typeof response === "string") {                        
                        response = response.replace(regexDate, 'new $1');                        
                        response = eval("(" + response + ")");
                    }
                    else if (typeof response === "object") {                        
                        // TODO
                        response = AudeebleSanitize_JsonObjectDates(response);
                    }

                    // Affectation des éléments de retour à l'objet Ajax
                    ajax.resultat           = response.ValeursRetour;
                    ajax.erreur             = response.Erreur;
                    ajax.erreurNonBloquante = !response.ErreurBloquante;
                    ajax.messageErreur      = response.MessageErreur;
                }


                // L'appel Ajax précise une gestion de succès spécifique
                if (req.success) {
                    if (isHtml) req.dataType = "html";
                    req.success(response, textStatus, jqXHR);
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {                
                // L'appel Ajax ne précise pas de gestion d'erreur spécifique
                if (!req.error) {
                    AudeebleUI_DisplayModalError("<p>Une erreur est survenue lors de la requête Ajax.</p>", "Erreur");                    
                }

                // L'appel Ajax précise une gestion d'erreur spécifique
                if (req.error) {
                    req.error(jqXHR, textStatus, errorThrown);
                }
            },
            complete: function (jqXHR, textStatus) {

                // Afficher erreur si :
                //  -> ajax.erreur = true
                //  -> textStatus == timeout
                //  -> 

                // sucess
                // notmodified
                // nocontent
                // error
                // timeout
                // abort
                // parsererror

                // Retrait du message d'attente
                if (req.affMessageAttente) {
                    // TODO
                }

                // L'appel Ajax précise le traitement à exécuter après l'envoi (réussi ou non)
                if (req.complete) {
                    req.complete(jqXHR, textStatus);
                }
            }
        });
    }
};