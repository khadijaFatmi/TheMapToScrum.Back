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
            retour.Name = objet.Name;
            retour.Firstname = objet.Firstname;
            return retour;

        }

        internal static List<DeveloperDTO> ToDto(List<Developer> liste)
        {
            List<DeveloperDTO> retour = new List<DeveloperDTO>();
            retour = liste.Select(x => new DeveloperDTO()
            {
                Name = x.Name,
                Firstname = x.Firstname,
                Id = x.Id,
                DateCreation = x.DateCreation,
                DateModification = x.DateModification,
                IsDeleted = x.IsDeleted


            })
        .ToList();
            return retour;

        }

    }
}
