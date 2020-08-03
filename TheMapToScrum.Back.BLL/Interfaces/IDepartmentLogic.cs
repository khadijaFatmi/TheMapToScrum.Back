using System.Collections.Generic;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface IDepartmentLogic
    {


        List<DepartmentDTO> List();
        List<DepartmentDTO> ListActive();

        DepartmentDTO Create(DepartmentDTO objet);

        DepartmentDTO Update(DepartmentDTO objet);
        bool Delete(int Id);
        DepartmentDTO GetById(int Id);


    }
}
