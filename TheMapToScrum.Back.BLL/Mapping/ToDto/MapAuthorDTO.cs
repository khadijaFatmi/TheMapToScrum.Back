using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Mapping
{

    internal static class MapAuthorDTO
    {
        internal static AuthorDTO ToDto(Author objet)
        {
            AuthorDTO retour = new AuthorDTO();
            retour.Name = objet.Name;
            return retour;
        }


        internal static List<AuthorDTO> ToDto(List<Author> liste)
        {
            List<AuthorDTO> retour = new List<AuthorDTO>();
            retour = liste.Select(x => new AuthorDTO()
            {

                Name = x.Name,
                Firstname = x.Firstname,
                Id = x.Id,
                DateCreation = x.DateCreation,
                DateModification = x.DateModification,
                IsDeleted = x.IsDeleted

            })
        .ToList();
            return retour;
        }
    }
}
