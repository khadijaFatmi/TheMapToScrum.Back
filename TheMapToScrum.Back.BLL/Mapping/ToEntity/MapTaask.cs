using System;
using System.Collections.Generic;
using System.Text;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapTaask
    {
        internal static Taask ToEntity(TaaskDTO obj, bool creation)
        {

            Taask retour = new Taask();
            if (obj != null)
            {
                retour.Label = obj.Label;                
                retour.Feature = obj.Feature;
                retour.EstimatedDuration = obj.EstimatedDuration;
                retour.Assumption = obj.Assumption;
                retour.Priority = obj.Priority;
                retour.Risk = obj.Risk;
                retour.AcceptanceCriteria = obj.AcceptanceCriteria;
                retour.TaskStatus = obj.TaskStatus;
                retour.ProjectId = obj.ProjectId;
                retour.UserStoryId = obj.UserStoryId;
                retour.DeveloperId = obj.DeveloperId;
                if (creation)
                {
                    retour.IsDeleted = false;
                    retour.DateCreation = DateTime.UtcNow;
                    retour.DateModification = DateTime.UtcNow;
                }
                else
                {
                    retour.Id = obj.Id;
                    retour.IsDeleted = obj.IsDeleted;
                    retour.DateCreation = obj.DateCreation;
                    retour.DateModification = DateTime.UtcNow;
                }
            }
            return retour;
        }
    }
}

  