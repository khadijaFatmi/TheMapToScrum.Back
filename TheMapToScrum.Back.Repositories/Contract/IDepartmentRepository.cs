using System.Collections.Generic;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.Repositories.Contract
{
    public interface IDepartmentRepository
    {
        Department Get(int id);

        List<Department> GetAll();

        List<Department> GetAllActive();

        Department Create(Department objet);

        Department Update(Department objet);

        bool Delete(int id);

    }
}
