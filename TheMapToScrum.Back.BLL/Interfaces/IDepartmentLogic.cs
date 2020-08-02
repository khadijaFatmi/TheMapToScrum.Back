using System.Collections.Generic;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface IDepartmentLogic
    {
        List<DepartmentDTO> Liste();

        DepartmentDTO Create(DepartmentDTO objet);

        DepartmentDTO Update(DepartmentDTO objet);


    }
}
