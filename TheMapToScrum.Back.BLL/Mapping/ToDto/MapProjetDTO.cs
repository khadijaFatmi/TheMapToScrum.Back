using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL
{
    internal static class MapProjetDTO
    {
        internal static ProjetDTO ToDto(TheMapToScrum.Back.DAL.Entities.Projet objet)
        {
            ProjetDTO retour = new ProjetDTO();
            if (null != objet)
            {
                retour.AuthorId = objet.AuthorId;
                retour.DateCreation = objet.DateCreation;
                retour.DateModification = objet.DateModification;
                retour.Id = objet.Id;
                retour.IsDeleted = objet.IsDeleted;
                retour.Name = objet.Name;
            }
            return retour;
            
        }

        
        internal static List<ProjetDTO> ToDto(List<TheMapToScrum.Back.DAL.Entities.Projet> liste)
        {
            //récupération de la liste d'entités USContentDTO transformés en entités
            List<ProjetDTO> retour = new List<ProjetDTO>();
            retour = liste.Select(x => new ProjetDTO()
            {
                Id = x.Id,
                AuthorId = x.AuthorId,
                DateCreation = x.DateCreation,
                DateModification = x.DateModification,
                IsDeleted = x.IsDeleted,
                Name = x.Name
                
                //proprietes dto

            }).ToList();
            return retour;
        }
    }
}
