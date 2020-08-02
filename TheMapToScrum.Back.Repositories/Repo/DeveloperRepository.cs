using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.Repositories.Repo
{
    public class DeveloperRepository : IDeveloperRepository
    {
        private readonly ApplicationContext _context;

        public DeveloperRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Developer Create(Developer objet)
        {
            _context.Developer.Add(objet);
            _context.SaveChanges();
            return objet;
        }

        public Developer Get(int id)
        {
            return _context.Developer
            .Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Developer> GetAll()
        {
            return _context.Developer
                .OrderByDescending(x => x.FirstName)
                .ToList();
        }

        public List<Developer> GetAllActive()
        {
            return _context.Developer
                .Where(x => !x.IsDeleted)
                .ToList();
        }

        public Developer Update(Developer entity)
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
