using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            bool resultat = false;
            try
            {
                Project entite = _context.Project.Where(x => x.Id == Id).First();
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

        public Project Get(int Id)
        {

            return _context.Project
                .Where(x => x.Id == Id).FirstOrDefault();
        }

        public List<Project> GetAll()
        {
            //proche bdd 
            return _context.Project
                .Include(d => d.Department)
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

