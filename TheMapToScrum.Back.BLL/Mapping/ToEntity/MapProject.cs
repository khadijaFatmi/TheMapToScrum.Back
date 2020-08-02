using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapProject
    {
        internal static Project MapToEntity(ProjectDTO objet)
        {
            Project retour = new Project();
            retour.BusinessManagerId = objet.BusinessManagerId;
            retour.DateCreation = objet.DateCreation;
            retour.DateModification = objet.DateModification;
            retour.Id = objet.Id;
            retour.IsDeleted = objet.IsDeleted;
            retour.Name = objet.Name;
            return retour;
        }
    }
}
