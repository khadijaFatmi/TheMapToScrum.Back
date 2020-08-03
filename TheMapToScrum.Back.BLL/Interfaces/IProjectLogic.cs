using System.Collections.Generic;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface IProjectLogic
    {
       

        List<ProjectDTO> List();
        List<ProjectDTO> ListActive();

        ProjectDTO Create(ProjectDTO objet);

        ProjectDTO Update(ProjectDTO objet);
        bool Delete(int Id);
        ProjectDTO GetById(int Id);
    }
}
