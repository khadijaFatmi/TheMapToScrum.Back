using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.Repositories.Repo
{
    public class ProjetRepository : IProjetRepository
    {
        private readonly ApplicationContext _context;


        public ProjetRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Projet Create(Projet objet)
        {
            _context.Projet.Add(objet);
            _context.SaveChanges();
            return objet;
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Projet Get(int id)
        {

            return _context.Projet
                .Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Projet> GetAll()
        {
            //proche bdd 
            return _context.Projet
                .OrderByDescending(x => x.Name)
                .ToList();

        }

        public List<Projet> GetAllActive()
        {
            return _context.Projet
                .OrderByDescending(x => x.Name)
                .Where(x => !x.IsDeleted)
                .ToList();
        }

        public Projet Update(Projet entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}

