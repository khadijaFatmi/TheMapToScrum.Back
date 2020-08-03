using System;
using System.Collections.Generic;


using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{
    internal static class MapTechnicalManager
    {
        internal static TechnicalManager ToEntity(TechnicalManagerDTO objet)
        {
            TechnicalManager retour = new TechnicalManager();
            retour.Id = objet.Id;
            retour.LastName = objet.LastName;
            retour.FirstName = objet.FirstName;           
            retour.IsDeleted = objet.IsDeleted;
            retour.DateCreation = objet.DateCreation;
            retour.DateCreation = objet.DateCreation;
            return retour;
        }
    }
}