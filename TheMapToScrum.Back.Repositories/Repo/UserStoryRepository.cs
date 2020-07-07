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
            throw new NotImplementedException();
        }

        public UserStoryContent Get(int id)
        {

            return _context.UserStoryContent
                .Where(x => x.Id == id).FirstOrDefault();
        }

        public List<UserStoryContent> GetAll()
        {
            //proche bdd 
            return _context.UserStoryContent.Include(p => p.Projet)
                .OrderByDescending(x => x.Name)
                .ToList();

        }

        public List<UserStoryContent> GetAllActive()
        {
            
            return _context.UserStoryContent.Include(p => p.Projet)
                .OrderByDescending(x => x.Name)
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
