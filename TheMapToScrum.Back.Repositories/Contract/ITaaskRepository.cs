using System.Collections.Generic;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.Repositories.Contract
{
    public interface ITaaskRepository
    {
        Taask Get(int Id);

        List<Taask> GetAll();

        List<Taask> GetAllActive();

        Taask Create(Taask objet);

        Taask Update(Taask objet);

        bool Delete(int Id);
        int GetNextNumberByUsId(int userStoryId);

        int GetNextNumberByProjectId(int id);
       
        List<Taask> GetByUsId(int id);

        List<Taask> GetByProjectId(int id);
  }
}
