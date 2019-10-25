using System;
using System.Collections.Generic;

namespace Audeeble_Shared.Utils
{
    public class AjaxResponse
    {
        public object       ValeursRetour { get; set; }        
        public bool         Erreur { get; set; }
        public bool         ErreurBloquante { get; set; }
        public string       MessageErreur { get; set; }
        public List<string> ListeErreurs { get; set; }

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public AjaxResponse()
        {
            this.ValeursRetour    = null;
            this.Erreur           = false;
            this.ErreurBloquante  = false;
            this.MessageErreur    = string.Empty;
            this.ListeErreurs     = new List<string>();
        }

        /// <summary>
        /// Ajout à la réponse des détails de l'exception levée.
        /// </summary>
        /// <param name="ex">Exception levée par la requête Ajax.</param>
        public void AddException(Exception ex)
        {
            this.AddError(ex.Message);
        }

        /// <summary>
        /// Ajout d'une erreur à la réponse.
        /// </summary>
        /// <param name="messageErreur">Message de l'erreur.</param>
        /// <param name="erreurBloquante">Booléen indiquant s'il s'agit ou non d'une erreur bloquante.</param>
        public void AddError(string messageErreur, bool erreurBloquante = true)
        {
            this.MessageErreur = messageErreur;
            
            if (erreurBloquante)
            {
                this.Erreur = true;
                this.ErreurBloquante = true;
            }

            this.ListeErreurs.Add(messageErreur);
        }
    }
}