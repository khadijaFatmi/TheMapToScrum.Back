using System.Collections.Generic;
using TheMapToScrum.Back.DTO;


namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface IUserStoryLogic
    {
               

        List<UserStoryContentDTO> list();
        List<UserStoryContentDTO> listActive();

        UserStoryContentDTO Create(UserStoryContentDTO objet);

        UserStoryContentDTO Update(UserStoryContentDTO objet);
        bool Delete(int id);
        UserStoryContentDTO GetById(int id);
    }
}
