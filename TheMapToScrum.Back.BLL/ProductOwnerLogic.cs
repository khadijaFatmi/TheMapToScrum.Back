using System.Collections.Generic;
using TheMapToScrum.Back.BLL.Interfaces;
using TheMapToScrum.Back.BLL.Mapping;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.DTO;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.BLL
{
    public class ProductOwnerLogic : IProductOwnerLogic
    {
        private readonly IProductOwnerRepository _repo;
        public ProductOwnerLogic(IProductOwnerRepository repo)
        {
            _repo = repo;
        }
       
        public ProductOwnerDTO Create(ProductOwnerDTO objet)
        {
            ProductOwner entite = MapProductOwner.ToEntity(objet, true);
            ProductOwner resultat = _repo.Create(entite);
            ProductOwnerDTO retour = MapProductOwnerDTO.ToDto(resultat);
            return retour;
        }

        public ProductOwnerDTO Update(ProductOwnerDTO objet)
        {
            ProductOwner entite = MapProductOwner.ToEntity(objet, false);
            ProductOwner resultat = _repo.Update(entite);
            ProductOwnerDTO retour = MapProductOwnerDTO.ToDto(resultat);
            return retour;
        }
        public List<ProductOwnerDTO> List() 
        {
            List<ProductOwnerDTO> retour = new List<ProductOwnerDTO>();
            List<ProductOwner> liste = _repo.GetAll();
            retour = MapProductOwnerDTO.ToDto(liste);
            return retour;

        }

        public List<ProductOwnerDTO> ListActive()
        {
            List<ProductOwnerDTO> retour = new List<ProductOwnerDTO>();
            List<ProductOwner> liste = _repo.GetAllActive();
            retour = MapProductOwnerDTO.ToDto(liste);
            return retour;

        }

        public ProductOwnerDTO GetById(int Id)
        {
            ProductOwnerDTO retour = new ProductOwnerDTO();
            ProductOwner objet = _repo.Get(Id);
            retour = MapProductOwnerDTO.ToDto(objet);
            return retour;
        }

        public bool Delete(int Id)
        {
            return _repo.Delete(Id);
        }
    }
}
