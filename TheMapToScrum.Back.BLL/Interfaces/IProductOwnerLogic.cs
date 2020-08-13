using System.Collections.Generic;
using TheMapToScrum.Back.DTO;

namespace TheMapToScrum.Back.BLL.Interfaces
{
    public interface IProductOwnerLogic
    {

        List<ProductOwnerDTO> List();
        List<ProductOwnerDTO> ListActive();

        ProductOwnerDTO Create(ProductOwnerDTO objet);

        ProductOwnerDTO Update(ProductOwnerDTO objet);
        bool Delete(int Id);
        ProductOwnerDTO GetById(int Id);


    }
}
