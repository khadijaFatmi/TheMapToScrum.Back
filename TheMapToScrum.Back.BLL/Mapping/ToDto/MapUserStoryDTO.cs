using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL
{
    internal static class MapUserStoryContentDTO
    {
        internal static UserStoryDTO ToDto(UserStory objet)
        {
            UserStoryDTO retour = new UserStoryDTO();
            if (objet != null)
            {
                retour.Id = objet.Id;
                retour.ProjectId = objet.ProjectId;               
                retour.Label = objet.Label;
                retour.Version = objet.Version;
                retour.Role = objet.Role;
                retour.Function1 = objet.Function1;
                retour.Function2 = objet.Function2;
                retour.Notes = objet.Notes;
                retour.Priority = objet.Priority;
                retour.StoryPoints = objet.StoryPoints;
                retour.EpicStory = objet.EpicStory;
                retour.IsDeleted = objet.IsDeleted;
                retour.DateCreation = (System.DateTime)objet.DateCreation;
                retour.DateModification = DateTime.UtcNow;
            }

            return retour;
        
        }


        internal static List<UserStoryDTO> ToDto(List<UserStory> liste)
        {
            //récupération de la liste d'entités USContentDTO transformés en entités
            List<UserStoryDTO> retour = new List<UserStoryDTO>();
            retour = liste.Select(x => new UserStoryDTO()
            {
                Id = x.Id,
                Version = x.Version,
                Label = x.Label,
                Role = x.Role,
                Project = MapProjectDTO.ToDto(x.Project),
                Priority = x.Priority,
                DateCreation = (System.DateTime)x.DateCreation,
                DateModification = (System.DateTime)x.DateModification,
                EpicStory = x.EpicStory,
                StoryPoints = x.StoryPoints,
                Function1 = x.Function1,
                Function2 = x.Function2,
                Notes = x.Notes,
                IsDeleted = x.IsDeleted,
                ProjectId = x.ProjectId

                



                //proprietes dto

            }).ToList();
            return retour;
        }
    }
}
