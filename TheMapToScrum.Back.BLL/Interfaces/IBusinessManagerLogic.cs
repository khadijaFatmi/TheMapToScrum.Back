using System.Collections.Generic;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface IBusinessManagerLogic
    {
        List<BusinessManagerDTO> Liste();

        BusinessManagerDTO Create(BusinessManagerDTO objet);

        BusinessManagerDTO Update(BusinessManagerDTO objet);


    }
}
