using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.Repositories.Repo
{
    public class ProductOwnerRepository : IProductOwnerRepository
    {
        private readonly ApplicationContext _context;

        public ProductOwnerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public ProductOwner Create(ProductOwner objet)
        {
            _context.ProductOwner.Add(objet);
            _context.SaveChanges();
            return objet;
        }

        public ProductOwner Get(int Id)
        {
            return _context.ProductOwner
            .Where(x => x.Id == Id).FirstOrDefault();
        }

        public List<ProductOwner> GetAll()
        {
            return _context.ProductOwner
                .OrderByDescending(x => x.FirstName)
                .ToList();
        }

        public List<ProductOwner> GetAllActive()
        {
            return _context.ProductOwner
                .OrderByDescending(x => x.FirstName)
                .Where(x => !x.IsDeleted)
                .ToList();
        }

        public ProductOwner Update(ProductOwner entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;

        }

        
        public bool Delete(int Id)
        {
            bool resultat = false;
            try
            {
                ProductOwner entite = _context.ProductOwner.Where(x => x.Id == Id).First();
                entite.IsDeleted = true;
                entite.DateModification = DateTime.UtcNow;
                _context.Update(entite);
                _context.SaveChanges();
                resultat = true;
            }
            catch (Exception ex)
            {
            }
            return resultat;
        }



    }
}
