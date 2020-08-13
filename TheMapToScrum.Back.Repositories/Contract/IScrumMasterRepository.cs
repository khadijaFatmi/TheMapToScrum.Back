using System.Collections.Generic;
using TheMapToScrum.Back.DAL.Entities;


namespace TheMapToScrum.Back.Repositories.Contract
{
    public interface IScrumMasterRepository
    {
        ScrumMaster Get(int Id);

        List<ScrumMaster> GetAll();

        List<ScrumMaster> GetAllActive();

        ScrumMaster Create(ScrumMaster objet);

        ScrumMaster Update(ScrumMaster objet);

        bool Delete(int Id);


    }
}
