using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL
{
    internal static class MapUserStoryContentDTO
    {
        internal static UserStoryContentDTO ToDto(UserStoryContent objet)
        {
            UserStoryContentDTO retour = new UserStoryContentDTO();
            if (objet != null)
            {
                retour.Id = objet.Id;
                retour.ProjectId = objet.ProjectId;
                retour.Titre = objet.Titre;
                retour.Name = objet.Name;
                retour.Version = objet.Version;
                retour.Role = objet.Role;
                retour.Function1 = objet.Function1;
                retour.Function2 = objet.Function2;
                retour.Notes = objet.Notes;
                retour.Priority = objet.Priority;
                retour.StoryPoints = objet.StoryPoints;
                retour.EpicStory = objet.EpicStory;
                retour.IsDeleted = objet.IsDeleted;
                retour.DateCreation = objet.DateCreation;
                retour.DateModification = DateTime.Now;
            }

            return retour;
        
        }


        internal static List<UserStoryContentDTO> ToDto(List<UserStoryContent> liste)
        {
            //récupération de la liste d'entités USContentDTO transformés en entités
            List<UserStoryContentDTO> retour = new List<UserStoryContentDTO>();
            retour = liste.Select(x => new UserStoryContentDTO()
            {
                Id = x.Id,
                Titre = x.Titre,
                Version = x.Version,
                Name = x.Name,
                Role = x.Role,
                Project = MapProjectDTO.ToDto(x.Project),
                Priority = x.Priority,
                DateCreation = x.DateCreation,
                DateModification = x.DateModification,
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
