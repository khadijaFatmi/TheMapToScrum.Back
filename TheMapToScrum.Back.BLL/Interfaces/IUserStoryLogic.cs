using System.Collections.Generic;
using TheMapToScrum.Back.DTO;


namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface IUserStoryLogic
    {
               

        List<UserStoryDTO> list();
        List<UserStoryDTO> listActive();

        UserStoryDTO Create(UserStoryDTO objet);

        UserStoryDTO Update(UserStoryDTO objet);
        bool Delete(int Id);
        UserStoryDTO GetById(int Id);
        List<UserStoryDTO> getByProjectId(int id);
  }
}
