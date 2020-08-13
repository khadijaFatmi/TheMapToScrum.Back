
using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapTeamDTO
    {
        internal static TeamDTO ToDto(Team objet)
        {
            TeamDTO retour = new TeamDTO();
            if (objet != null)
            {
                retour.Id = objet.Id;
                retour.Label = objet.Label;               
                retour.IsDeleted = objet.IsDeleted;
                retour.DateCreation = (System.DateTime)objet.DateCreation;
                retour.DateModification = (System.DateTime)objet.DateModification;
            }

            return retour;

        }


        internal static List<TeamDTO> ToDto(List<Team> liste)
        {
            //récupération de la liste d'entités TeamDTO transformés en entités
            List<TeamDTO> retour = new List<TeamDTO>();
            retour = liste.Select(x => new TeamDTO()
            {
                Id = x.Id,              
                Label = x.Label,               
                DateCreation = (System.DateTime)x.DateCreation,
                DateModification = (System.DateTime)x.DateModification,
                IsDeleted = x.IsDeleted,
               
            }).ToList();
            return retour;
        }
    }
}
