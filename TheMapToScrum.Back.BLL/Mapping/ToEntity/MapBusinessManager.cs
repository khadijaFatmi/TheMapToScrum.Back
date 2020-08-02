using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapBusinessManager
    {
        internal static BusinessManager MapToEntity(BusinessManagerDTO objet)
        {
            BusinessManager retour = new BusinessManager();
            retour.Name = objet.Name;
            retour.Firstname = objet.Firstname;
            retour.Id = objet.Id;
            retour.IsDeleted = objet.IsDeleted;
            retour.DateCreation = objet.DateCreation;
            retour.DateCreation = objet.DateCreation;
            return retour;
        }
    }
}
