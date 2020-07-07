using System.Collections.Generic;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.Repositories.Contract
{
    public interface IPoleRepository
    {
        Pole Get(int id);

        List<Pole> GetAll();

        List<Pole> GetAllActive();

        Pole Create(Pole objet);

        Pole Update(Pole objet);

        bool Delete(int id);

    }
}
