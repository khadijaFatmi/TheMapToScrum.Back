using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapDepartment
    {
        internal static Department MapToEntity(DepartmentDTO objet)
        {
            Department retour = new Department();
            retour.Name = objet.Name;
            retour.Id = objet.Id;
            retour.DateCreation = objet.DateCreation;
            retour.DateModification = objet.DateModification;
            retour.IsDeleted = objet.IsDeleted;
            return retour;
        }
    }
}
