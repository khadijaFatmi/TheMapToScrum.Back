using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.BLL.Mapping;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL
{
    internal static class MapProjectDTO
    {
        internal static ProjectDTO ToDto(Project objet)
        {
            ProjectDTO retour = new ProjectDTO();
            if (null != objet)
            {
                retour.Id = objet.Id;
                retour.Label = objet.Label;
                retour.BusinessManagerId = objet.BusinessManagerId;
                retour.TeamId = objet.TeamId;
                retour.TechnicalManagerId = objet.TechnicalManagerId;
                retour.DepartmentId = objet.DepartmentId;
                retour.Department = MapDepartmentDTO.ToDto(objet.Department);
                retour.TechnicalManager = MapTechnicalManagerDTO.ToDto(objet.TechnicalManager);
                retour.BusinessManager = MapBusinessManagerDTO.ToDto(objet.BusinessManager);
                retour.Team = MapTeamDTO.ToDto(objet.Team);                
                retour.DateCreation = objet.DateCreation;
                retour.DateModification = objet.DateModification;               
                retour.IsDeleted = objet.IsDeleted;
               
            }
            return retour;
            
        }

        
        internal static List<ProjectDTO> ToDto(List<TheMapToScrum.Back.DAL.Entities.Project> liste)
        {
            List<ProjectDTO> retour = new List<ProjectDTO>();
            retour = liste.Select(x => new ProjectDTO()
            {
                Id = x.Id,
                DepartmentId = x.DepartmentId,
                BusinessManagerId = x.BusinessManagerId,
                TeamId = x.TeamId,
                TechnicalManagerId = x.TechnicalManagerId,
                Department = MapDepartmentDTO.ToDto(x.Department),
                BusinessManager = MapBusinessManagerDTO.ToDto(x.BusinessManager),
                TechnicalManager = MapTechnicalManagerDTO.ToDto(x.TechnicalManager),
                Team = MapTeamDTO.ToDto(x.Team),
                DateCreation = x.DateCreation,
                DateModification = x.DateModification,
                IsDeleted = x.IsDeleted,
                Label = x.Label
            }).ToList();
            return retour;
        }
    }
}
