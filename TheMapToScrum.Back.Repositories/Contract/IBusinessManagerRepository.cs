using System.Collections.Generic;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.Repositories.Contract
{
    public interface IBusinessManagerRepository
    {
        BusinessManager Get(int id);



        List<BusinessManager> GetAll();

        List<BusinessManager> GetAllActive();

        BusinessManager Create(BusinessManager objet);

        BusinessManager Update(BusinessManager objet);

        bool Delete(int Id);
    }
}
