using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.Common.Enums;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;


namespace TheMapToScrum.Back.BLL.Mapping
{
  
    internal static class MapTaaskDTO
    {
        // MapTaaskDTO prend un entite et traduit, renvoie un DTO
        internal static TaaskDTO ToDto(Taask obj)
        {
      TaaskDTO result = new TaaskDTO();
            if(obj != null)
            {
                result.Id = obj.Id;
                result.Label = obj.Label;
                result.Number = obj.Number;
                result.Feature = obj.Feature;
                result.EstimatedDuration = obj.EstimatedDuration;
                result.Assumption = obj.Assumption;
                result.AcceptanceCriteria = obj.AcceptanceCriteria;
                result.Risk = obj.Risk;
                result.TaskStatus = obj.TaskStatus;
                result.Priority = obj.Priority;
                result.strPriorityColor = GetPriorityColor(obj.Priority);
                result.strStatusColor = GetStatusColor(obj.TaskStatus);

                result.strTaskStatus = ProcessStatus(obj.TaskStatus); 
                result.ProjectId = obj.ProjectId;
                result.DeveloperId = obj.DeveloperId;
                result.UserStoryId = obj.UserStoryId.HasValue ? obj.UserStoryId : 0;
                result.IsDeleted = obj.IsDeleted;
                result.DateCreation = (System.DateTime)obj.DateCreation;
                result.DateModification = DateTime.UtcNow;
                //TaaskDTO contient les propriétés DTO (US, Project & Dev)
                //pour que le DTO de retour les contienne 
                result.UserStory = MapUserStoryDTO.ToDto(obj.UserStory);

            }
            return result;
        }


        internal static List<TaaskDTO> ToDto(List<Taask> liste)
        {
            //récupération de la liste d'entités TaaskDTO transformés en entités
            List<TaaskDTO> result = new List<TaaskDTO>();
      result = liste.Select(x => new TaaskDTO()
      {
        Id = x.Id,
        Label = x.Label,
        Number = x.Number,
        Feature = x.Feature,
        EstimatedDuration = x.EstimatedDuration,
        Assumption = x.Assumption,
        AcceptanceCriteria = x.AcceptanceCriteria,
        Risk = x.Risk,
        Priority = x.Priority,
        strPriority = GetPriority(x.Priority),
        TaskStatus = x.TaskStatus,
        strTaskStatus = ProcessStatus(x.TaskStatus),
        IsDeleted = x.IsDeleted,
        ProjectId = x.ProjectId,
        DeveloperId = x.DeveloperId,
        UserStoryId = x.UserStoryId,
        strPriorityColor = "#3300ff", // GetPriorityColor(x.Priority),
        strStatusColor = GetStatusColor(x.TaskStatus),
        Project = MapProjectDTO.ToDto(x.Project),
        Developer = MapDeveloperDTO.ToDto(x.Developer),
        UserStory = x.UserStory != null ? MapUserStoryDTO.ToDto(x.UserStory) : null,
        USLabel = x.UserStory == null ? "No US Linked Yet" : x.UserStory.Label,
        DateCreation = (System.DateTime)x.DateCreation,
        DateModification = (System.DateTime)x.DateModification,
      }).ToList();
            return result;
        }

        // conversion, par réflexion, des id de Statut du Processus, Priorité & Statut en string, ici pour l'entité Task

        private static string GetPriority(int idPriority)
        {
            string result = ((ePriority)idPriority).ToString();
            return result;
        }
        private static string GetStatusColor(int idStatus)
        {
            string result = ((eTaskStatus)idStatus).ToString();
            return result;
        }

        private static string GetPriorityColor(int idPriority) 
        {
            string result = ((eTaskStatus)idPriority).ToString();
            return result;
        }
        private static string ProcessStatus(int idStatus)
        {
            
            string result = ((eTaskStatus)idStatus).ToString();

            return result;
        }
    }
}



 


