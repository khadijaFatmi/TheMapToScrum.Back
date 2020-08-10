using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.DAL.Entities;
using System;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapDeveloper
    {
        internal static Developer ToEntity(DeveloperDTO objet, bool creation)
        {
            Developer retour = new Developer();
            if (objet != null)
            {                
                retour.LastName = objet.LastName;
                retour.FirstName = objet.FirstName;
                if(creation)
                {
                    retour.DateCreation = DateTime.UtcNow;
                    retour.DateModification = DateTime.UtcNow;
                    retour.IsDeleted = false;
                }
                else
                {
                    retour.Id = objet.Id;
                    retour.DateCreation = objet.DateCreation;
                    retour.DateModification = DateTime.UtcNow;
                    retour.IsDeleted = objet.IsDeleted;
                }
               
            }
            return retour;
        }
    }
}
