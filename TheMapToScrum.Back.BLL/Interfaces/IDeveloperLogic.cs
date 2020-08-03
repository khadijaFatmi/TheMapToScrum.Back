using System.Collections.Generic;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface IDeveloperLogic
    {

        List<DeveloperDTO> List();
        List<DeveloperDTO> ListActive();

        DeveloperDTO Create(DeveloperDTO objet);

        DeveloperDTO Update(DeveloperDTO objet);
        bool Delete(int Id);
        DeveloperDTO GetById(int Id);



    }
}
