using System;
using System.Collections.Generic;
using TheMapToScrum.Back.DTO;


namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface ITeamLogic
    {


        List<TeamDTO> list();
        List<TeamDTO> listActive();

        TeamDTO Create(TeamDTO objet);

        TeamDTO Update(TeamDTO objet);
        bool Delete(int id);
        TeamDTO GetById(int id);
    }
}
