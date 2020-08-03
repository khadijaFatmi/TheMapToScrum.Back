using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{

    internal static class MapBusinessManagerDTO
    {
        internal static BusinessManagerDTO ToDto(BusinessManager objet)
        {
            BusinessManagerDTO retour = new BusinessManagerDTO();
            if (objet != null)
            {
                retour.Id = objet.Id;
                retour.LastName = objet.LastName;
                retour.FirstName = objet.FirstName;
            }
            return retour;
        }


        internal static List<BusinessManagerDTO> ToDto(List<BusinessManager> liste)
        {
            List<BusinessManagerDTO> retour = new List<BusinessManagerDTO>();
            retour = liste.Select(x => new BusinessManagerDTO()
            {
                Id = x.Id,
                LastName = x.LastName,
                FirstName = x.FirstName,
                DateCreation = x.DateCreation,
                DateModification = x.DateModification,
                IsDeleted = x.IsDeleted

            })
        .ToList();
            return retour;
        }
    }
}
