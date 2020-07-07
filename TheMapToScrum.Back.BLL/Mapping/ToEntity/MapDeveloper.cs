using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapDeveloper
    {
        internal static Developer MapToEntity(DeveloperDTO objet)
        {
            Developer retour = new Developer();
            retour.Name = objet.Name;
            retour.Firstname = objet.Firstname;
            retour.Id = objet.Id;
            retour.DateCreation = objet.DateCreation;
            retour.DateModification = objet.DateModification;
            retour.IsDeleted = objet.IsDeleted;
            return retour;
        }

        internal static Developer MapToDTO(DeveloperDTO objet)
        {
            Developer retour = new Developer();
            retour.Name = objet.Name;
            retour.Firstname = objet.Firstname;
            retour.Id = objet.Id;
            retour.DateCreation = objet.DateCreation;
            retour.DateModification = objet.DateModification;
            retour.IsDeleted = objet.IsDeleted;
            return retour;
        }

    }
}
