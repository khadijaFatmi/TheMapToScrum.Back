using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.BLL.Mapping;
using TheMapToScrum.Back.Common.Enums;
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
                retour.ProductOwnerId = objet.ProductOwnerId;
                retour.TeamId = objet.TeamId;
                retour.ScrumMasterId = objet.ScrumMasterId;
                retour.DepartmentId = objet.DepartmentId;
                retour.Department = MapDepartmentDTO.ToDto(objet.Department);
                retour.ScrumMaster= MapScrumMasterDTO.ToDto(objet.TechnicalManager);
                retour.ProductOwner = MapProductOwnerDTO.ToDto(objet.ProductOwner);
                retour.Team = MapTeamDTO.ToDto(objet.Team);
                retour.ProjectStatus = objet.ProjectStatus;
                retour.strProjectStatus = ProcessStatus(objet.ProjectStatus);
                retour.DateCreation = (System.DateTime)objet.DateCreation;
                retour.DateModification = (System.DateTime)objet.DateModification;               
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
                ProductOwnerId = x.ProductOwnerId,
                TeamId = x.TeamId,
                ScrumMasterId = x.ScrumMasterId,
                Department = MapDepartmentDTO.ToDto(x.Department),
                ProductOwner = MapProductOwnerDTO.ToDto(x.ProductOwner),
                ScrumMaster = MapScrumMasterDTO.ToDto(x.TechnicalManager),
                Team = MapTeamDTO.ToDto(x.Team),
                ProjectStatus = x.ProjectStatus,
                strProjectStatus = ProcessStatus(x.ProjectStatus),
                DateCreation = (System.DateTime)x.DateCreation,
                DateModification = (System.DateTime)x.DateModification,
                IsDeleted = x.IsDeleted,
                Label = x.Label
            }).ToList();
            return retour;
        }


        private static string ProcessStatus(int idStatus)
        {
            // conversion, par réflexion, des id de status en string, ici pour l'entité Project
            string resultat = ((eProjectStatus)idStatus).ToString();

            return resultat;
        }
    }
}
