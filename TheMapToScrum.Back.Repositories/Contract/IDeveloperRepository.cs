using System.Collections.Generic;
using TheMapToScrum.Back.DAL.Entities;



namespace TheMapToScrum.Back.Repositories.Contract
{
    public interface IDeveloperRepository
    {
        Developer Get(int Id);

        List<Developer> GetAll();

        List<Developer> GetAllActive();

        Developer Create(Developer objet);

        Developer Update(Developer objet);

        bool Delete(int Id);
    }
}
