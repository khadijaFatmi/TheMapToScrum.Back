using System.Collections.Generic;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.Repositories.Contract
{
    public interface IAuthorRepository
    {
        Author Get(int id);



        List<Author> GetAll();

        List<Author> GetAllActive();

        Author Create(Author objet);

        Author Update(Author objet);

        bool Delete(int Id);
    }
}
