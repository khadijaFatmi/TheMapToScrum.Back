using System.Collections.Generic;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface IPoleLogic
    {
        List<PoleDTO> Liste();

        PoleDTO Create(PoleDTO objet);

        PoleDTO Update(PoleDTO objet);


    }
}
