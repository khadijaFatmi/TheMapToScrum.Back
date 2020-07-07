using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapPoleDTO
    {
        internal static PoleDTO ToDto(Pole objet)
        {
            PoleDTO retour = new PoleDTO();
            retour.Name = objet.Name;
            return retour;
        }


        internal static List<PoleDTO> ToDto(List<Pole> liste)
        {
            List<PoleDTO> retour = new List<PoleDTO>();
            retour = liste.Select(x => new PoleDTO()
            {

                Name = x.Name,
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
