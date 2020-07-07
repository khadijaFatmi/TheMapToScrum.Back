using System;
using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.BLL.Mapping;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.BLL
{
    public class DeveloperLogic : IDeveloperLogic
        
    {
        private readonly IDeveloperRepository _repo;

        public DeveloperLogic(IDeveloperRepository repo)
        {
            _repo = repo;
        }
        public List<DeveloperDTO> Liste()
        {
            List<DeveloperDTO> retour = new List<DeveloperDTO>();
            List<Developer> liste = _repo.GetAll();
            retour = MapDeveloperDTO.ToDto(liste);
            return retour;


        }

        public DeveloperDTO Create(DeveloperDTO objet)
        {
            Developer entite = MapDeveloper.MapToEntity(objet);
            Developer resultat = _repo.Create(entite);

            objet = MapDeveloperDTO.ToDto(resultat);
            return objet;
        }

        public DeveloperDTO Update(DeveloperDTO objet)
        {
            Developer entity = MapDeveloper.MapToEntity(objet);
            Developer resultat = _repo.Update(entity);
            DeveloperDTO retour = MapDeveloperDTO.ToDto(resultat);
            return retour;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
