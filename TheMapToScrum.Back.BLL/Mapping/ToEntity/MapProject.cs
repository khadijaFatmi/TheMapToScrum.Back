using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapProject
    {
        internal static Project MapToEntity(ProjectDTO objet)
        {
            Project retour = new Project();
            retour.Id = objet.Id;
            retour.Label = objet.Label;
            retour.BusinessManagerId = objet.BusinessManagerId;
            retour.DateCreation = objet.DateCreation;
            retour.DateModification = objet.DateModification;
            retour.IsDeleted = objet.IsDeleted;
            
            return retour;
        }
    }
}
