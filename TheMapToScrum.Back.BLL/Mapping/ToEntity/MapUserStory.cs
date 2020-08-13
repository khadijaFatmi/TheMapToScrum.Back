using System;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapUserStory
    {

        internal static UserStory ToEntity(UserStoryDTO objet, bool creation)
        {
            UserStory retour = new UserStory();
            if (objet != null)
            {
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
                if (creation)
                {
                    retour.IsDeleted = false;
                    retour.DateCreation = DateTime.UtcNow;
                    retour.DateModification = objet.DateCreation;
                }
                else
                {
                    retour.Id = objet.Id;
                    retour.IsDeleted = objet.IsDeleted;
                    retour.DateCreation = objet.DateCreation;
                    retour.DateModification = DateTime.UtcNow;                    
                }               
            }
            return retour;
        }
    }
}
