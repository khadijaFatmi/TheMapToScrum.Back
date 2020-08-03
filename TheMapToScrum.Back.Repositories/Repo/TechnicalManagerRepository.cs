using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;


namespace TheMapToScrum.Back.Repositories.Repo
{
    public class TechnicalManagerRepository : ITechnicalManagerRepository
    {
        private readonly ApplicationContext _context;

        public TechnicalManagerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public TechnicalManager Create(TechnicalManager objet)
        {
            _context.TechnicalManager.Add(objet);
            _context.SaveChanges();
            return objet;
        }

        public TechnicalManager Get(int id)
        {
            return _context.TechnicalManager
            .Where(x => x.Id == id).FirstOrDefault();
        }


        public List<TechnicalManager> GetAll()
        {
            return _context.TechnicalManager
                .OrderByDescending(x => x.FirstName)
                .ToList();
        }

        public List<TechnicalManager> GetAllActive()
        {
            return _context.TechnicalManager
                .OrderByDescending(x => x.FirstName)
                .Where(x => !x.IsDeleted)
                .ToList();
        }

        public TechnicalManager Update(TechnicalManager entity)
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
                TechnicalManager entite = _context.TechnicalManager.Where(x => x.Id == Id).First();
                entite.IsDeleted = true;
                entite.DateModification = DateTime.Now;
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
