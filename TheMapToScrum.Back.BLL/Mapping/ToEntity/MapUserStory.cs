using System.Runtime.CompilerServices;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapUserStory
    {

        internal static UserStoryContent MapToEntity(UserStoryContentDTO objet)
        {
            UserStoryContent retour = new UserStoryContent();
            
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
            retour.DateModification = objet.DateModification;
            return retour;
        }
    }
}
