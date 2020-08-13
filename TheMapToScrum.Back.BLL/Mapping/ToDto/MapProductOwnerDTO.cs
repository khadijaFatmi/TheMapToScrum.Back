using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{

    internal static class MapProductOwnerDTO
    {
        internal static ProductOwnerDTO ToDto(ProductOwner objet)
        {
            ProductOwnerDTO retour = new ProductOwnerDTO();
            if (objet != null)
            {
                retour.Id = objet.Id;
                retour.LastName = objet.LastName;
                retour.FirstName = objet.FirstName;
                retour.FullName = objet.FirstName + " " + objet.LastName;
                retour.IsDeleted = objet.IsDeleted;
                retour.DateCreation = (System.DateTime)objet.DateCreation;
                retour.DateModification = (System.DateTime)objet.DateModification;
            }
            return retour;
        }


        internal static List<ProductOwnerDTO> ToDto(List<ProductOwner> liste)
        {
            List<ProductOwnerDTO> retour = new List<ProductOwnerDTO>();
            retour = liste.Select(x => new ProductOwnerDTO()
            {
                Id = x.Id,
                LastName = x.LastName,
                FirstName = x.FirstName,
                FullName = x.FirstName + " " + x.LastName,
                DateCreation = (System.DateTime)x.DateCreation,
                DateModification = (System.DateTime)x.DateModification,
                IsDeleted = x.IsDeleted

            })
        .ToList();
            return retour;
        }
    }
}
