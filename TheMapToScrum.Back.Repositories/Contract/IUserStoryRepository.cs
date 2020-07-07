using System.Collections.Generic;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.Repositories.Contract
{
    public interface IUserStoryRepository
    {
        UserStoryContent Get(int id);

        List<UserStoryContent> GetAll();

        List<UserStoryContent> GetAllActive();

        UserStoryContent Create(UserStoryContent objet);

        UserStoryContent Update(UserStoryContent objet);

        bool Delete(int Id);
    }
}
