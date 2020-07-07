using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.Repositories.Repo
{
    public class PoleRepository : IPoleRepository
    {
        private readonly ApplicationContext _context;


        public PoleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Pole Create(Pole objet)
        {
            _context.Pole.Add(objet);
            _context.SaveChanges();
            return objet;
        }

        public Pole Get(int id)
        {
            return _context.Pole
                .Where(x => x.Id == id).FirstOrDefault();

        }

        public List<Pole> GetAll()
        {
            return _context.Pole
                .OrderByDescending(x => x.Name)
                .ToList();
        }

        public List<Pole> GetAllActive()
        {
            return _context.Pole
                .OrderByDescending(x => x.Name)
                .Where(x => !x.IsDeleted)
                .ToList();
        }

        public Pole Update(Pole entity)
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
