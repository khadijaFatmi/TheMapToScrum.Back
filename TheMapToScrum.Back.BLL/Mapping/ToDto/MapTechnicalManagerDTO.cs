using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapTechnicalManagerDTO
    {

        internal static TechnicalManagerDTO ToDto(TechnicalManager objet)
        {
            TechnicalManagerDTO retour = new TechnicalManagerDTO();
            if (objet != null)
            {
                retour.Id = objet.Id;
                retour.LastName = objet.LastName;
                retour.FirstName = objet.FirstName;
                retour.FullName = objet.FirstName + " " + objet.LastName;
                retour.IsDeleted = objet.IsDeleted;
                retour.DateCreation = objet.DateCreation;
                retour.DateModification = objet.DateModification;
            }
            return retour;
        }


        internal static List<TechnicalManagerDTO> ToDto(List<TechnicalManager> liste)
        {
            List<TechnicalManagerDTO> retour = new List<TechnicalManagerDTO>();
            retour = liste.Select(x => new TechnicalManagerDTO()
            {

                Id = x.Id,
                LastName = x.LastName,
                FullName = x.FirstName + " " + x.LastName,
                FirstName = x.FirstName,              
                DateCreation = x.DateCreation,
                DateModification = x.DateModification,
                IsDeleted = x.IsDeleted

            })
        .ToList();
            return retour;
        }
    }
}

