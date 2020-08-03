using System.Collections.Generic;
using TheMapToScrum.Back.DTO;


namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface ITechnicalManagerLogic
    {
        List<TechnicalManagerDTO> List();
        List<TechnicalManagerDTO> ListActive();

        TechnicalManagerDTO Create(TechnicalManagerDTO objet);

        TechnicalManagerDTO Update(TechnicalManagerDTO objet);
        bool Delete(int Id);
        TechnicalManagerDTO GetById(int Id);
    }
}
