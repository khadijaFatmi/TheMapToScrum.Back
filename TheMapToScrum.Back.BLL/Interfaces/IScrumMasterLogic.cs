using System.Collections.Generic;
using TheMapToScrum.Back.DTO;


namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface IScrumMasterLogic
    {
        List<ScrumMasterDTO> List();
        List<ScrumMasterDTO> ListActive();

        ScrumMasterDTO Create(ScrumMasterDTO objet);

        ScrumMasterDTO Update(ScrumMasterDTO objet);
        bool Delete(int Id);
        ScrumMasterDTO GetById(int Id);
    }
}
