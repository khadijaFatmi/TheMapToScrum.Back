using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapPole
    {
        internal static Pole MapToEntity(PoleDTO objet)
        {
            Pole retour = new Pole();
            retour.Name = objet.Name;
            retour.Id = objet.Id;
            retour.DateCreation = objet.DateCreation;
            retour.DateModification = objet.DateModification;
            retour.IsDeleted = objet.IsDeleted;
            return retour;
        }
    }
}
