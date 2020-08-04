using System.Collections.Generic;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface IBusinessManagerLogic
    {

        List<BusinessManagerDTO> List();
        List<BusinessManagerDTO> ListActive();

        BusinessManagerDTO Create(BusinessManagerDTO objet);

        BusinessManagerDTO Update(BusinessManagerDTO objet);
        bool Delete(int Id);
        BusinessManagerDTO GetById(int Id);


    }
}
