using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapDepartmentDTO
    {
        internal static DepartmentDTO ToDto(Department objet)
        {
            DepartmentDTO retour = new DepartmentDTO();
            if (objet != null)
            {
                retour.Label = objet.Label;
            }
                return retour;
        }


        internal static List<DepartmentDTO> ToDto(List<Department> liste)
        {
            List<DepartmentDTO> retour = new List<DepartmentDTO>();
            retour = liste.Select(x => new DepartmentDTO()
            {

                Label = x.Label,
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
