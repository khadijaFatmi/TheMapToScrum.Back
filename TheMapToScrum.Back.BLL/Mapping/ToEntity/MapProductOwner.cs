using System;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapProductOwner
    {
        internal static ProductOwner ToEntity(ProductOwnerDTO objet, bool creation)
        {
            ProductOwner retour = new ProductOwner();
            if (objet != null)
            {
                
                retour.LastName = objet.LastName;
                retour.FirstName = objet.FirstName;
                if (creation)
                {
                    retour.IsDeleted = false;
                    retour.DateCreation = DateTime.UtcNow;
                    retour.DateModification = DateTime.UtcNow;
                }
                else 
                {
                    retour.Id = objet.Id;
                    retour.IsDeleted = objet.IsDeleted;
                    retour.DateCreation = objet.DateCreation;
                    retour.DateModification = DateTime.UtcNow;
                }
                
            }            
            return retour;
        }
    }
}
