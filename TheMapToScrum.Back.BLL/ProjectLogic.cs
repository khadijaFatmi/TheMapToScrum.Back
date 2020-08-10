using System;
using System.Collections.Generic;
using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.BLL.Mapping;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.BLL
{
    public class ProjectLogic : IProjectLogic
    {
        private readonly IProjectRepository _repo;

        public ProjectLogic(IProjectRepository repo)
        {
            _repo = repo;
        }

        public ProjectDTO Create(ProjectDTO objet)
        {
            Project entite = MapProject.ToEntity(objet, true);
            Project resultat = _repo.Create(entite);

            objet = MapProjectDTO.ToDto(resultat);
            return objet;
        }


        public ProjectDTO GetById(int Id)
        {
            ProjectDTO retour = new ProjectDTO();
            Project objet = _repo.Get(Id);
            retour = MapProjectDTO.ToDto(objet);
            return retour;

        }

        public ProjectDTO Update(ProjectDTO objet)
        {
            Project entity = MapProject.ToEntity(objet, false);
            Project resultat = _repo.Update(entity);
            ProjectDTO retour = MapProjectDTO.ToDto(resultat);
            return retour;
        }


        public bool Delete(int Id)
        {

            bool resultat = _repo.Delete(Id);
            return resultat;
        }

        public List<ProjectDTO> List()
        {
            List<ProjectDTO> retour = new List<ProjectDTO>();
            List<Project> liste = _repo.GetAll();
            retour = MapProjectDTO.ToDto(liste);
            return retour;
        }
        public List<ProjectDTO> ListActive()
        {
            List<ProjectDTO> retour = new List<ProjectDTO>();
            List<Project> liste = _repo.GetAllActive();
            retour = MapProjectDTO.ToDto(liste);
            return retour;
        }

    }
}

