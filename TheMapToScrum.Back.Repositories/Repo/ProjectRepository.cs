using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.Repositories.Repo
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationContext _context;


        public ProjectRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Project Create(Project objet)
        {
            _context.Project.Add(objet);
            _context.SaveChanges();
            return objet;
        }

        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Project Get(int id)
        {

            return _context.Project
                .Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Project> GetAll()
        {
            //proche bdd 
            return _context.Project
                .OrderByDescending(x => x.Label)
                .ToList();

        }

        public List<Project> GetAllActive()
        {
            return _context.Project
                .OrderByDescending(x => x.Label)
                .Where(x => !x.IsDeleted)
                .ToList();
        }

        public Project Update(Project entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}

