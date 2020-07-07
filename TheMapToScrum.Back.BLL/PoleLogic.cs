using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.BLL.Mapping;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.BLL
{
    public class PoleLogic : IPoleLogic
    {
        private readonly IPoleRepository _repo;

        public PoleLogic(IPoleRepository repo)
        {
            _repo = repo;
        }

        public PoleDTO Create(PoleDTO objet)
        {
            Pole entite = MapPole.MapToEntity(objet);
            Pole resultat = _repo.Create(entite);
            return objet;
        }

        public PoleDTO Update(PoleDTO objet)
        {
            Pole entite = MapPole.MapToEntity(objet);
            Pole resultat = _repo.Update(entite);
            PoleDTO retour = MapPoleDTO.ToDto(resultat);
            return retour;
        }
        public List<PoleDTO> Liste()
        {
            List<PoleDTO> retour = new List<PoleDTO>();
            List<Pole> liste = _repo.GetAll();
            retour = MapPoleDTO.ToDto(liste);
            return retour;

        }

        public PoleDTO GetById(int id)
        {
            PoleDTO retour = new PoleDTO();
            Pole objet = _repo.Get(id);
            retour = MapPoleDTO.ToDto(objet);
            return retour;
        }


    }
}
