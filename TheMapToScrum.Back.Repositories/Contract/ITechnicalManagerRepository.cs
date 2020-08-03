using System.Collections.Generic;
using TheMapToScrum.Back.DAL.Entities;


namespace TheMapToScrum.Back.Repositories.Contract
{
    public interface ITechnicalManagerRepository
    {
        TechnicalManager Get(int id);

        List<TechnicalManager> GetAll();

        List<TechnicalManager> GetAllActive();

        TechnicalManager Create(TechnicalManager objet);

        TechnicalManager Update(TechnicalManager objet);

        bool Delete(int Id);


    }
}
