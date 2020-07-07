using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.BLL.Mapping;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.BLL
{
    public class AuthorLogic : IAuthorLogic
    {
        private readonly IAuthorRepository _repo;
        public AuthorLogic(IAuthorRepository repo)
        {
            _repo = repo;
        }
       
        public AuthorDTO Create(AuthorDTO objet)
        {
            Author entite = MapAuthor.MapToEntity(objet);
            Author resultat = _repo.Create(entite);
            return objet;
        }

        public AuthorDTO Update(AuthorDTO objet)
        {
            Author entite = MapAuthor.MapToEntity(objet);
            Author resultat = _repo.Update(entite);
            AuthorDTO retour = MapAuthorDTO.ToDto(resultat);
            return retour;
        }
        public List<AuthorDTO> Liste() 
        {
            List<AuthorDTO> retour = new List<AuthorDTO>();
            List<Author> liste = _repo.GetAll();
            retour = MapAuthorDTO.ToDto(liste);
            return retour;

        }

        public AuthorDTO GetById(int id)
        {
            AuthorDTO retour = new AuthorDTO();
            Author objet = _repo.Get(id);
            retour = MapAuthorDTO.ToDto(objet);
            return retour;
        }

    }
}
