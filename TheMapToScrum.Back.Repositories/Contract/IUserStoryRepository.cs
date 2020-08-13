using System.Collections.Generic;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.Repositories.Contract
{
    public interface IUserStoryRepository
    {
        UserStory Get(int Id);

        List<UserStory> GetAll();

        List<UserStory> GetAllActive();

        UserStory Create(UserStory objet);

        UserStory Update(UserStory objet);

        bool Delete(int Id);
    }
}
