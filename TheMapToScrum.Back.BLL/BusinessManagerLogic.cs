using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.BLL.Mapping;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.BLL
{
    public class BusinessManagerLogic : IBusinessManagerLogic
    {
        private readonly IBusinessManagerRepository _repo;
        public BusinessManagerLogic(IBusinessManagerRepository repo)
        {
            _repo = repo;
        }
       
        public BusinessManagerDTO Create(BusinessManagerDTO objet)
        {
            BusinessManager entite = MapBusinessManager.MapToEntity(objet);
            BusinessManager resultat = _repo.Create(entite);
            return objet;
        }

        public BusinessManagerDTO Update(BusinessManagerDTO objet)
        {
            BusinessManager entite = MapBusinessManager.MapToEntity(objet);
            BusinessManager resultat = _repo.Update(entite);
            BusinessManagerDTO retour = MapBusinessManagerDTO.ToDto(resultat);
            return retour;
        }
        public List<BusinessManagerDTO> Liste() 
        {
            List<BusinessManagerDTO> retour = new List<BusinessManagerDTO>();
            List<BusinessManager> liste = _repo.GetAll();
            retour = MapBusinessManagerDTO.ToDto(liste);
            return retour;

        }

        public BusinessManagerDTO GetById(int id)
        {
            BusinessManagerDTO retour = new BusinessManagerDTO();
            BusinessManager objet = _repo.Get(id);
            retour = MapBusinessManagerDTO.ToDto(objet);
            return retour;
        }

    }
}
