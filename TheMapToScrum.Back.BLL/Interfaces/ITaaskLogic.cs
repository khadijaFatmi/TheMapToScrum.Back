using System.Collections.Generic;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface ITaaskLogic
    {
        List<TaaskDTO> List();
        List<TaaskDTO> ListActive();

        TaaskDTO GetById(int id);
        TaaskDTO Create(TaaskDTO entity);
        TaaskDTO Update(TaaskDTO entity);
        bool Delete(int Id);
        List<TaaskDTO> ListeByUsId(int id);

        List<TaaskDTO> ListeByProjectId(int id);
  }
}
