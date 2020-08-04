using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapTeam
    {
        internal static Team ToEntity(TeamDTO objet)
        {
            Team retour = new Team();
            retour.Id = objet.Id;
            retour.Label = objet.Label;    
            retour.DateCreation = objet.DateCreation;
            retour.DateModification = objet.DateModification;
            retour.IsDeleted = objet.IsDeleted;
            return retour;
        }

    }
}
