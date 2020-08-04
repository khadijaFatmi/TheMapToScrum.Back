using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapDeveloper
    {
        internal static Developer ToEntity(DeveloperDTO objet)
        {
            Developer retour = new Developer();
            retour.Id = objet.Id;
            retour.LastName = objet.LastName;
            retour.FirstName = objet.FirstName;
            retour.DateCreation = objet.DateCreation;
            retour.DateModification = objet.DateModification;
            retour.IsDeleted = objet.IsDeleted;
            return retour;
        }

    }
}
