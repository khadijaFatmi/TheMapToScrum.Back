using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.Common.Enums;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL
{
  internal static class MapUserStoryDTO
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
        retour.strPriority = GetUsPriority((int)objet.Priority);
        retour.StoryPoints = objet.StoryPoints;
        retour.EpicStory = objet.EpicStory;
        retour.usStatus = objet.usStatus;
        retour.strUsStatus = ProcessStatus(objet.usStatus);
        retour.IsDeleted = objet.IsDeleted;
        retour.DateCreation = (System.DateTime)objet.DateCreation;
        retour.DateModification = DateTime.UtcNow;
        retour.Project = MapProjectDTO.ToDto(objet.Project);
        retour.nbTasks = objet.nbTasks;
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
        strPriority = x.Priority.HasValue ? GetUsPriority((int)x.Priority) : string.Empty,
        Priority = x.Priority,
        DateCreation = (System.DateTime)x.DateCreation,
        DateModification = (System.DateTime)x.DateModification,
        EpicStory = x.EpicStory,
        usStatus = x.usStatus,
        strUsStatus = ProcessStatus(x.usStatus),
        StoryPoints = x.StoryPoints,
        Function1 = x.Function1,
        Function2 = x.Function2,
        Notes = x.Notes,
        IsDeleted = x.IsDeleted,
        ProjectId = x.ProjectId,
        nbTasks = (int)x.nbTasks
        //proprietes dto

      }).ToList();
      return retour;
    }


    private static string GetUsPriority(int? idPriority)
    {
      
        string result = ((eUsPriority)idPriority).ToString();
        return result;
      
    }

    private static string ProcessStatus(int idStatus)
    {
      // conversion, par réflexion, des id de status en string, ici pour l'entité UserStory
      string resultat = ((eUsStatus)idStatus).ToString();

      return resultat;
    }
  }
}
