using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.Repositories.Repo
{
    public class BusinessManagerRepository : IBusinessManagerRepository
    {
        private readonly ApplicationContext _context;

        public BusinessManagerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public BusinessManager Create(BusinessManager objet)
        {
            _context.BusinessManager.Add(objet);
            _context.SaveChanges();
            return objet;
        }

        public BusinessManager Get(int id)
        {
            return _context.BusinessManager
            .Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BusinessManager> GetAll()
        {
            return _context.BusinessManager
                .OrderByDescending(x => x.Name)
                .ToList();
        }

        public List<BusinessManager> GetAllActive()
        {
            return _context.BusinessManager
                .OrderByDescending(x => x.Name)
                .Where(x => !x.IsDeleted)
                .ToList();
        }

        public BusinessManager Update(BusinessManager entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;

        }

        //inutilisée (cf suppression logique IsDeleted)
        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }



    }
}
