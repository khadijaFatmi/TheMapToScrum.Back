using System.Collections.Generic;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.Repositories.Contract
{
    public interface IProjectRepository 
    {
        Project Get(int id);



        List<Project> GetAll();

        List<Project> GetAllActive();

        Project Create(Project objet);

        Project Update(Project objet);

        bool Delete(int Id);
    }
}
