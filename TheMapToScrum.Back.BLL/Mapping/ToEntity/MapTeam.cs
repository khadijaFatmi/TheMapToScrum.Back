using System;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapTeam
    {
        internal static Team ToEntity(TeamDTO objet, bool creation)
        {
            Team retour = new Team();
            if (objet != null)
            {

                retour.Label = objet.Label;
                if (creation)
                {
                    retour.DateCreation = DateTime.UtcNow;
                    retour.DateModification = retour.DateCreation;
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
