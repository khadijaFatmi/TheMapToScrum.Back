using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapScrumMasterDTO
    {

        internal static ScrumMasterDTO ToDto(ScrumMaster objet)
        {
            ScrumMasterDTO retour = new ScrumMasterDTO();
            if (objet != null)
            {
                retour.Id = objet.Id;
                retour.LastName = objet.LastName;
                retour.FirstName = objet.FirstName;
                retour.FullName = objet.FirstName + " " + objet.LastName;
                retour.IsDeleted = objet.IsDeleted;
                retour.DateCreation = (System.DateTime)objet.DateCreation;
                retour.DateModification = (System.DateTime)objet.DateModification;
            }
            return retour;
        }


        internal static List<ScrumMasterDTO> ToDto(List<ScrumMaster> liste)
        {
            List<ScrumMasterDTO> retour = new List<ScrumMasterDTO>();
            retour = liste.Select(x => new ScrumMasterDTO()
            {

                Id = x.Id,
                LastName = x.LastName,
                FullName = x.FirstName + " " + x.LastName,
                FirstName = x.FirstName,              
                DateCreation = (System.DateTime)x.DateCreation,
                DateModification = (System.DateTime)x.DateModification,
                IsDeleted = x.IsDeleted

            })
        .ToList();
            return retour;
        }
    }
}

