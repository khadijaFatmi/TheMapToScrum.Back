using System.Collections.Generic;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.Repositories.Contract
{
    public interface IProductOwnerRepository
    {
        ProductOwner Get(int Id);



        List<ProductOwner> GetAll();

        List<ProductOwner> GetAllActive();

        ProductOwner Create(ProductOwner objet);

        ProductOwner Update(ProductOwner objet);

        bool Delete(int Id);
    }
}
