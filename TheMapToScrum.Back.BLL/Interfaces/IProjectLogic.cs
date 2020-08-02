using System.Collections.Generic;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface IProjectLogic
    {
        List<ProjectDTO> Liste();

        ProjectDTO Create(ProjectDTO objet);

        ProjectDTO Update(ProjectDTO objet);
    }
}
