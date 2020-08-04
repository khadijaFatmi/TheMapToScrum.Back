using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.BLL.Mapping;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.BLL
{
    public class TeamLogic : ITeamLogic
    {
        private readonly ITeamRepository _repo;
        public TeamLogic(ITeamRepository repo)
        {
            _repo = repo;
        }

        public TeamDTO Create(TeamDTO objet)
        {
            Team entite = MapTeam.ToEntity(objet);
            Team resultat = _repo.Create(entite);
            return objet;
        }

        public TeamDTO Update(TeamDTO objet)
        {
            Team entite = MapTeam.ToEntity(objet);
            Team resultat = _repo.Update(entite);
            TeamDTO retour = MapTeamDTO.ToDto(resultat);
            return retour;
        }
        public List<TeamDTO> List()
        {
            List<TeamDTO> retour = new List<TeamDTO>();
            List<Team> liste = _repo.GetAll();
            retour = MapTeamDTO.ToDto(liste);
            return retour;

        }

        public List<TeamDTO> ListActive()
        {
            List<TeamDTO> retour = new List<TeamDTO>();
            List<Team> liste = _repo.GetAllActive();
            retour = MapTeamDTO.ToDto(liste);
            return retour;

        }

        public TeamDTO GetById(int Id)
        {
            TeamDTO retour = new TeamDTO();
            Team objet = _repo.Get(Id);
            retour = MapTeamDTO.ToDto(objet);
            return retour;
        }

        public bool Delete(int Id)
        {
            return _repo.Delete(Id);
        }
    }
}
