using System;
using System.Collections.Generic;
using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.BLL.Mapping;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.BLL
{
    public class ProjetLogic : IProjetLogic
    {
        private readonly IProjetRepository _repo;

        public ProjetLogic(IProjetRepository repo)
        {
            _repo = repo;
        }

        public ProjetDTO Create(ProjetDTO objet)
        {
            Projet entite = MapProjet.MapToEntity(objet);
            Projet resultat = _repo.Create(entite);

            objet = MapProjetDTO.ToDto(resultat);
            return objet;
        }

        public ProjetDTO Update(ProjetDTO objet)
        {
            Projet entity = MapProjet.MapToEntity(objet);
            Projet resultat = _repo.Update(entity);
            ProjetDTO retour = MapProjetDTO.ToDto(resultat);
            return retour;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProjetDTO GetById(int id)
        {
            ProjetDTO retour = new ProjetDTO();
            Projet objet = _repo.Get(id);
            retour = MapProjetDTO.ToDto(objet);
            return retour;

        }

        public List<ProjetDTO> Liste()
        {
            List<ProjetDTO> retour = new List<ProjetDTO>();
            List<Projet> liste = _repo.GetAll();
            retour = MapProjetDTO.ToDto(liste);
            return retour;
        }
        public List<ProjetDTO> listActive()
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
//    public class ProjetLogic : IProjetLogic
//    {
//        public List<ProjetDTO> Liste()
//        {
//            List<ProjetDTO> retour = new List<ProjetDTO>();

//            ProjetDTO projet = new ProjetDTO()
//            {
//                Id = 1,
//                IsDeleted = false,
//                Libelle = "Scrum Me If You Can",
//                Auteur = "Gilles",
//                Equipe = "le Bon, La Brute & le Truand",
//                Pole = "Production",
//                Datecreation = new DateTime(2019, 8, 16)
//            };

//            ProjetDTO projet1 = new ProjetDTO()
//            {
//                Id = 2,
//                IsDeleted = false,
//                Libelle = "Odyssey",
//                Auteur = "Stanley",
//                Equipe = "Kubrick",
//                Pole = "Nasa",
//                Datecreation = new DateTime(1968, 9, 27)
//            };
//            ProjetDTO projet2 = new ProjetDTO()
//            {
//                Id = 3,
//                IsDeleted = false,
//                Libelle = "Fight Club",
//                Auteur = "David",
//                Equipe = "Fincher",
//                Pole = "Marketing",
//                Datecreation = new DateTime(1999, 9, 10)
//            };
//            ProjetDTO projet3 = new ProjetDTO()
//            {
//                Id = 4,
//                IsDeleted = false,
//                Libelle = "WTC",
//                Auteur = "Oussama",
//                Equipe = "La Fine",
//                Pole = "Communication",
//                Datecreation = new DateTime(2001, 9, 11)
//            };
//            ProjetDTO projet4 = new ProjetDTO()
//            {
//                Id = 5,
//                IsDeleted = false,
//                Libelle = "C20",
//                Auteur = "Billy",
//                Equipe = "OMS",
//                Pole = "Sante",
//                Datecreation = new DateTime(2020, 3, 1)
//            };
//            ProjetDTO projet5 = new ProjetDTO()
//            {
//                Id = 6,
//                IsDeleted = false,
//                Libelle = "Aware",
//                Auteur = "JCVD",
//                Equipe = "Any",
//                Pole = "Direction",
//                Datecreation = new DateTime(2000, 8, 1)
//            };

//            ProjetDTO projet6 = new ProjetDTO()
//            {
//                Id = 7,
//                IsDeleted = false,
//                Libelle = "Skywalker",
//                Auteur = "Anakin",
//                Equipe = "Jedi",
//                Pole = "DeathStar",
//                Datecreation = new DateTime(2545, 1, 1)
//            };

//            retour.Add(projet);
//            retour.Add(projet1);
//            retour.Add(projet2);
//            retour.Add(projet3);
//            retour.Add(projet4);
//            retour.Add(projet5);
//            retour.Add(projet6);

//            return retour;



//        }
//    }
//}
