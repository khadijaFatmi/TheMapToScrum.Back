using System.Collections.Generic;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface IAuthorLogic
    {
        List<AuthorDTO> Liste();

        AuthorDTO Create(AuthorDTO objet);

        AuthorDTO Update(AuthorDTO objet);


    }
}
