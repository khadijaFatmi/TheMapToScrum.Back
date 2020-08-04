using System.Collections.Generic;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.Repositories.Contract
{
    public interface ITeamRepository
    {
        Team Get(int Id);



        List<Team> GetAll();

        List<Team> GetAllActive();

        Team Create(Team objet);

        Team Update(Team objet);

        bool Delete(int Id);
    }
}
