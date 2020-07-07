using System.Collections.Generic;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface IDeveloperLogic
    {

        List<DeveloperDTO> Liste();

        DeveloperDTO Create(DeveloperDTO objet);


        DeveloperDTO Update(DeveloperDTO objet);




    }
}
