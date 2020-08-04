using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapBusinessManager
    {
        internal static BusinessManager ToEntity(BusinessManagerDTO objet)
        {
            BusinessManager retour = new BusinessManager();
            retour.Id = objet.Id;
            retour.LastName = objet.LastName;
            retour.FirstName = objet.FirstName;
            retour.IsDeleted = objet.IsDeleted;
            retour.DateCreation = objet.DateCreation;
            retour.DateCreation = objet.DateCreation;
            return retour;
        }
    }
}
