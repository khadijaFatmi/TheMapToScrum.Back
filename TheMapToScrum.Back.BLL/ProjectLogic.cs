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
            Project entite = MapProject.ToEntity(objet);
            Project resultat = _repo.Create(entite);

            objet = MapProjectDTO.ToDto(resultat);
            return objet;
        }

        public ProjectDTO Update(ProjectDTO objet)
        {
            Project entity = MapProject.ToEntity(objet);
            Project resultat = _repo.Update(entity);
            ProjectDTO retour = MapProjectDTO.ToDto(resultat);
            return retour;
        }


        public bool Delete(int Id)
        {

            bool resultat = _repo.Delete(Id);
            return resultat;
        }

        public ProjectDTO GetById(int Id)
        {
            ProjectDTO retour = new ProjectDTO();
            Project objet = _repo.Get(Id);
            retour = MapProjectDTO.ToDto(objet);
            return retour;

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
            throw new NotImplementedException();
        }

    }
}



//using System;
//using System.Collections.Generic;
//using System.Text;
//using UserStoriesWF.DTO;
//using UserStory.BLL.Interfaces;

//namespace UserStory.BLL
//{
//    public class ProjectLogic : IProjectLogic
//    {
//        public List<ProjectDTO> Liste()
//        {
//            List<ProjectDTO> retour = new List<ProjectDTO>();

//            ProjectDTO project = new ProjectDTO()
//            {
//                Id = 1,
//                IsDeleted = false,
//                Libelle = "Scrum Me If You Can",
//                Auteur = "Gilles",
//                Equipe = "le Bon, La Brute & le Truand",
//                Department = "Production",
//                Datecreation = new DateTime(2019, 8, 16)
//            };

//            ProjectDTO project1 = new ProjectDTO()
//            {
//                Id = 2,
//                IsDeleted = false,
//                Libelle = "Odyssey",
//                Auteur = "Stanley",
//                Equipe = "Kubrick",
//                Department = "Nasa",
//                Datecreation = new DateTime(1968, 9, 27)
//            };
//            ProjectDTO project2 = new ProjectDTO()
//            {
//                Id = 3,
//                IsDeleted = false,
//                Libelle = "Fight Club",
//                Auteur = "David",
//                Equipe = "Fincher",
//                Department = "Marketing",
//                Datecreation = new DateTime(1999, 9, 10)
//            };
//            ProjectDTO project3 = new ProjectDTO()
//            {
//                Id = 4,
//                IsDeleted = false,
//                Libelle = "WTC",
//                Auteur = "Oussama",
//                Equipe = "La Fine",
//                Department = "Communication",
//                Datecreation = new DateTime(2001, 9, 11)
//            };
//            ProjectDTO project4 = new ProjectDTO()
//            {
//                Id = 5,
//                IsDeleted = false,
//                Libelle = "C20",
//                Auteur = "Billy",
//                Equipe = "OMS",
//                Department = "Sante",
//                Datecreation = new DateTime(2020, 3, 1)
//            };
//            ProjectDTO project5 = new ProjectDTO()
//            {
//                Id = 6,
//                IsDeleted = false,
//                Libelle = "Aware",
//                Auteur = "JCVD",
//                Equipe = "Any",
//                Department = "Direction",
//                Datecreation = new DateTime(2000, 8, 1)
//            };

//            ProjectDTO project6 = new ProjectDTO()
//            {
//                Id = 7,
//                IsDeleted = false,
//                Libelle = "Skywalker",
//                Auteur = "Anakin",
//                Equipe = "Jedi",
//                Department = "DeathStar",
//                Datecreation = new DateTime(2545, 1, 1)
//            };

//            retour.Add(project);
//            retour.Add(project1);
//            retour.Add(project2);
//            retour.Add(project3);
//            retour.Add(project4);
//            retour.Add(project5);
//            retour.Add(project6);

//            return retour;



//        }
//    }
//}
