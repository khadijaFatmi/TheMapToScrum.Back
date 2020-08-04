using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.BLL.Mapping;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.Repositories.Contract;
using TheMapToScrum.Back.Repositories.Repo;

namespace TheMapToScrum.Back.BLL
{
    public class TechnicalManagerLogic : ITechnicalManagerLogic

    {
        private readonly ITechnicalManagerRepository _repo;

        public TechnicalManagerLogic(ITechnicalManagerRepository repo)
        {
            _repo = repo;
        }

        public List<TechnicalManagerDTO> List()
        {
            List<TechnicalManagerDTO> retour = new List<TechnicalManagerDTO>();
            List<TechnicalManager> liste = _repo.GetAll();
            retour = MapTechnicalManagerDTO.ToDto(liste);
            return retour;


        }

        public List<TechnicalManagerDTO> ListActive()
        {
            List<TechnicalManagerDTO> retour = new List<TechnicalManagerDTO>();
            List<TechnicalManager> liste = _repo.GetAllActive();
            retour = MapTechnicalManagerDTO.ToDto(liste);
            return retour;
        }

        public TechnicalManagerDTO Create(TechnicalManagerDTO objet)
        {
            TechnicalManager entite = MapTechnicalManager.ToEntity(objet);
            TechnicalManager resultat = _repo.Create(entite);

            objet = MapTechnicalManagerDTO.ToDto(resultat);
            return objet;
        }

        public TechnicalManagerDTO Update(TechnicalManagerDTO objet)
        {
            TechnicalManager entity = MapTechnicalManager.ToEntity(objet);
            TechnicalManager resultat = _repo.Update(entity);
            TechnicalManagerDTO retour = MapTechnicalManagerDTO.ToDto(resultat);
            return retour;
        }

        public TechnicalManagerDTO GetById(int Id)
        {
            TechnicalManagerDTO retour = new TechnicalManagerDTO();
            TechnicalManager objet = _repo.Get(Id);
            retour = MapTechnicalManagerDTO.ToDto(objet);
            return retour;

        }


        public bool Delete(int Id)
        {

            bool resultat = _repo.Delete(Id);
            return resultat;
        }
    }
}
