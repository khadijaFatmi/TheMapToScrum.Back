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

        public UserStoryContent Create(UserStoryContent objet)
        {
            _context.UserStoryContent.Add(objet);
            _context.SaveChanges();
            return objet;
        }

        public bool Delete(int Id)
        {
            bool resultat = false;
            try
            {
                // select * from
                UserStoryContent entite = _context.UserStoryContent.Where(x => x.Id == Id).First();
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

        public UserStoryContent Get(int Id)
        {

            return _context.UserStoryContent
                .Where(x => x.Id == Id).FirstOrDefault();
        }

        public List<UserStoryContent> GetAll()
        {          
            return _context.UserStoryContent
                //.Include(p => p.Project)
                .OrderByDescending(x => x.Label)
                .ToList();

        }

        public List<UserStoryContent> GetAllActive()
        {            
            return _context.UserStoryContent
                .Include(p => p.Project)
                .OrderByDescending(x => x.Label)
                .Where(x => !x.IsDeleted)
                .ToList();
        }

        public UserStoryContent Update(UserStoryContent entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
