using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.Repositories.Repo
{
    public class UserStoryRepository : IUserStoryRepository
    {
        private readonly ApplicationContext _context;

        public UserStoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public UserStory Create(UserStory objet)
        {
            _context.UserStory.Add(objet);
            _context.SaveChanges();
            return objet;
        }

        public bool Delete(int Id)
        {
            bool resultat = false;
            try
            {
                // select * from
                UserStory entite = _context.UserStory.Where(x => x.Id == Id).First();
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

        public UserStory Get(int Id)
        {

            return _context.UserStory
                .Where(x => x.Id == Id).FirstOrDefault();
        }

        public List<UserStory> GetAll()
        {          
            return _context.UserStory
                //.Include(p => p.Project)
                .OrderByDescending(x => x.Label)
                .ToList();

        }

        public List<UserStory> GetAllActive()
        {            
            return _context.UserStory
                .Include(p => p.Project)
                .OrderByDescending(x => x.Label)
                .Where(x => !x.IsDeleted)
                .ToList();
        }

        public UserStory Update(UserStory entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
