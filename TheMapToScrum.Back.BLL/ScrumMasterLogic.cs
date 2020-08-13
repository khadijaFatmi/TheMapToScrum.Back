using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.BLL.Mapping;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.Repositories.Contract;
using TheMapToScrum.Back.Repositories.Repo;

namespace TheMapToScrum.Back.BLL
{
    public class ScrumMasterLogic : IScrumMasterLogic

    {
        private readonly IScrumMasterRepository _repo;

        public ScrumMasterLogic(IScrumMasterRepository repo)
        {
            _repo = repo;
        }

        public List<ScrumMasterDTO> List()
        {
            List<ScrumMasterDTO> retour = new List<ScrumMasterDTO>();
            List<ScrumMaster> liste = _repo.GetAll();
            retour = MapScrumMasterDTO.ToDto(liste);
            return retour;


        }

        public List<ScrumMasterDTO> ListActive()
        {
            List<ScrumMasterDTO> retour = new List<ScrumMasterDTO>();
            List<ScrumMaster> liste = _repo.GetAllActive();
            retour = MapScrumMasterDTO.ToDto(liste);
            return retour;
        }

        public ScrumMasterDTO Create(ScrumMasterDTO objet)
        {
            ScrumMaster entite = MapScrumMaster.ToEntity(objet, true);
            ScrumMaster resultat = _repo.Create(entite);

            objet = MapScrumMasterDTO.ToDto(resultat);
            return objet;
        }

        public ScrumMasterDTO Update(ScrumMasterDTO objet)
        {
            ScrumMaster entity = MapScrumMaster.ToEntity(objet, false);
            ScrumMaster resultat = _repo.Update(entity);
            ScrumMasterDTO retour = MapScrumMasterDTO.ToDto(resultat);
            return retour;
        }

        public ScrumMasterDTO GetById(int Id)
        {
            ScrumMasterDTO retour = new ScrumMasterDTO();
            ScrumMaster objet = _repo.Get(Id);
            retour = MapScrumMasterDTO.ToDto(objet);
            return retour;

        }


        public bool Delete(int Id)
        {

            bool resultat = _repo.Delete(Id);
            return resultat;
        }
    }
}
