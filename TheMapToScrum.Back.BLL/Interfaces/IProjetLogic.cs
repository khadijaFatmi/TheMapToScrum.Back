using System.Collections.Generic;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface IProjetLogic
    {
        List<ProjetDTO> Liste();

        ProjetDTO Create(ProjetDTO objet);

        ProjetDTO Update(ProjetDTO objet);
    }
}
