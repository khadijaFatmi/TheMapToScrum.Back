using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL
{
    internal static class MapProjectDTO
    {
        internal static ProjectDTO ToDto(TheMapToScrum.Back.DAL.Entities.Project objet)
        {
            ProjectDTO retour = new ProjectDTO();
            if (null != objet)
            {
                retour.BusinessManagerId = objet.BusinessManagerId;
                retour.DateCreation = objet.DateCreation;
                retour.DateModification = objet.DateModification;
                retour.Id = objet.Id;
                retour.IsDeleted = objet.IsDeleted;
                retour.Label = objet.Label;
            }
            return retour;
            
        }

        
        internal static List<ProjectDTO> ToDto(List<TheMapToScrum.Back.DAL.Entities.Project> liste)
        {
            //récupération de la liste d'entités USContentDTO transformés en entités
            List<ProjectDTO> retour = new List<ProjectDTO>();
            retour = liste.Select(x => new ProjectDTO()
            {
                Id = x.Id,
                BusinessManagerId = (int)x.BusinessManagerId,
                DateCreation = x.DateCreation,
                DateModification = x.DateModification,
                IsDeleted = x.IsDeleted,
                Label = x.Label
                
                //proprietes dto

            }).ToList();
            return retour;
        }
    }
}
