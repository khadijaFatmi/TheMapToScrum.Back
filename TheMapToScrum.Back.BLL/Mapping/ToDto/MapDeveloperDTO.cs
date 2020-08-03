using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapDeveloperDTO
    {

        internal static DeveloperDTO ToDto(Developer objet)
        {
            DeveloperDTO retour = new DeveloperDTO();
            if (objet != null)
            {
                retour.Id = objet.Id;
                retour.LastName = objet.LastName;
                retour.FirstName = objet.FirstName;
            }
            return retour;

        }

        internal static List<DeveloperDTO> ToDto(List<Developer> liste)
        {
            List<DeveloperDTO> retour = new List<DeveloperDTO>();
            retour = liste.Select(x => new DeveloperDTO()
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
