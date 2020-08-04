using System;
using System.Collections.Generic;
using TheMapToScrum.Back.DTO;


namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface ITeamLogic
    {


        List<TeamDTO> List();
        List<TeamDTO> ListActive();

        TeamDTO Create(TeamDTO objet);

        TeamDTO Update(TeamDTO objet);
        bool Delete(int Id);
        TeamDTO GetById(int Id);
    }
}
