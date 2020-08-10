using System;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapDepartment
    {
        internal static Department ToEntity(DepartmentDTO objet, bool creation)
        {
            Department retour = new Department();
            if (objet != null)
            {
                
                retour.Label = objet.Label;
                if(creation)
                {
                    retour.DateCreation = DateTime.UtcNow;
                    retour.DateModification = DateTime.UtcNow;
                    retour.IsDeleted =false;
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
