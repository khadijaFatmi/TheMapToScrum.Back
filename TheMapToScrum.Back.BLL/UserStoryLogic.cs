using System;
using System.Collections.Generic;
using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.BLL.Mapping;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.BLL
{
    public class UserStoryLogic : IUserStoryLogic
    {
        private readonly IUserStoryRepository _repo;

        public UserStoryLogic(IUserStoryRepository repo)
        {
            _repo = repo;
        }
        public UserStoryContentDTO Create(UserStoryContentDTO objet)
        {
            UserStoryContent entite = MapUserStory.MapToEntity(objet);
            UserStoryContent resultat = _repo.Create(entite);

            objet = MapUserStoryContentDTO.ToDto(resultat);
            return objet;
        }

        public UserStoryContentDTO Update(UserStoryContentDTO objet)
        {
            UserStoryContent entity = MapUserStory.MapToEntity(objet);
            UserStoryContent resultat = _repo.Update(entity);
            UserStoryContentDTO retour = MapUserStoryContentDTO.ToDto(resultat);
            return retour;
        }

        public bool Delete(int id)
        {
           
            bool resultat = _repo.Delete(id);
            return resultat;
        }

        public UserStoryContentDTO GetById(int id)
        {
            UserStoryContentDTO retour = new UserStoryContentDTO();
            UserStoryContent objet = _repo.Get(id);
            retour = MapUserStoryContentDTO.ToDto(objet);
            return retour;

        }

        public List<UserStoryContentDTO> list()
        {
            List<UserStoryContentDTO> retour = new List<UserStoryContentDTO>();
            List<UserStoryContent> liste = _repo.GetAll();
            retour = MapUserStoryContentDTO.ToDto(liste);
            return retour;
        }
        public List<UserStoryContentDTO> listActive()
        {
            List<UserStoryContentDTO> retour = new List<UserStoryContentDTO>();
            List<UserStoryContent> liste = _repo.GetAllActive();
            retour = MapUserStoryContentDTO.ToDto(liste);
            return retour;
        }

       
    }
}
