using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;


namespace TheMapToScrum.Back.Repositories.Repo
{
    public class ScrumMasterRepository : IScrumMasterRepository
    {
        private readonly ApplicationContext _context;

        public ScrumMasterRepository(ApplicationContext context)
        {
            _context = context;
        }

        public ScrumMaster Create(ScrumMaster objet)
        {
            _context.ScrumMaster.Add(objet);
            _context.SaveChanges();
            return objet;
        }

        public ScrumMaster Get(int Id)
        {
            return _context.ScrumMaster
            .Where(x => x.Id == Id).FirstOrDefault();
        }


        public List<ScrumMaster> GetAll()
        {
            return _context.ScrumMaster
                .OrderByDescending(x => x.FirstName)
                .ToList();
        }

        public List<ScrumMaster> GetAllActive()
        {
            return _context.ScrumMaster
                .OrderByDescending(x => x.FirstName)
                .Where(x => !x.IsDeleted)
                .ToList();
        }

        public ScrumMaster Update(ScrumMaster entity)
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
                ScrumMaster entite = _context.ScrumMaster.Where(x => x.Id == Id).First();
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
