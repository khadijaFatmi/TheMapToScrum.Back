using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.Repositories.Repo
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationContext _context;

        public TeamRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Team Create(Team objet)
        {
            _context.Team.Add(objet);
            _context.SaveChanges();
            return objet;
        }

        public Team Get(int Id)
        {
            return _context.Team
            .Where(x => x.Id == Id).FirstOrDefault();
        }

        public List<Team> GetAll()
        {
            return _context.Team
                .OrderByDescending(x => x.Label)
                .ToList();
        }

        public List<Team> GetAllActive()
        {
            return _context.Team
                .OrderByDescending(x => x.Label)
                .Where(x => !x.IsDeleted)
                .ToList();
        }

        public Team Update(Team entity)
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
                Team entite = _context.Team.Where(x => x.Id == Id).First();
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
