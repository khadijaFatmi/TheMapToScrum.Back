using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapProjet
    {
        internal static Projet MapToEntity(ProjetDTO objet)
        {
            Projet retour = new Projet();
            retour.AuthorId = objet.AuthorId;
            retour.DateCreation = objet.DateCreation;
            retour.DateModification = objet.DateModification;
            retour.Id = objet.Id;
            retour.IsDeleted = objet.IsDeleted;
            retour.Name = objet.Name;
            return retour;
        }
    }
}
