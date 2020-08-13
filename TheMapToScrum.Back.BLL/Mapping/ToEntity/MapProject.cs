using System;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapProject
    {
        internal static Project ToEntity(ProjectDTO objet, bool creation)
        {
            Project retour = new Project();
            if (objet != null)
            {
                retour.Label = objet.Label;
                retour.ProductOwnerId = objet.ProductOwnerId;
                retour.TeamId = objet.TeamId;
                retour.ScrumMasterId = objet.ScrumMasterId;
                retour.DepartmentId = objet.DepartmentId;

                if (creation)
                {
                    retour.DateCreation = DateTime.UtcNow;
                    retour.DateModification = DateTime.UtcNow;
                    retour.IsDeleted = false;
                }
                else
                {
                    retour.Id = objet.Id;
                    retour.DateCreation = objet.DateCreation;
                    retour.DateModification = DateTime.UtcNow;
                    retour.IsDeleted = objet.IsDeleted;
                }
            }
            return retour;
        }
    }
}
