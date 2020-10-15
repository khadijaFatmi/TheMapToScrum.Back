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



        public Project Get(int Id)
        {

            return _context.Project
                .Where(x => x.Id == Id).FirstOrDefault();
        }

        public List<Project> GetAll()
        {

            List<Project> retour = _context.Project
                .Include(d => d.Department)
                .Include(t => t.Team)
                .Include(tm => tm.ScrumMaster)
                .Include(bm => bm.ProductOwner)
                .OrderBy(x => x.Label)
                .ToList();
            return retour;

        }

        public List<Project> GetAllActive()
        {
            List<Project> retour = _context.Project
                .Include(d => d.Department)
                .Include(t => t.Team)
                .Include(tm => tm.ScrumMaster)
                .Include(bm => bm.ProductOwner)
                .OrderBy(x => x.Label)
                .Where(x => (bool)!x.IsDeleted)
                .ToList();
             return retour;
        }

        public Project Update(Project entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public bool Delete(int Id)
        {
            bool resultat = true;
            

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    //Delete project
                    Project entite = _context.Project.Where(x => x.Id == Id).First();
                    entite.IsDeleted = true;
                    entite.DateModification = DateTime.UtcNow;
                    _context.Update(entite);
                    _context.SaveChanges();



                    //Delete UserStory linked to the current project
                    //get all (list) userstories with the projectId
                    List<UserStory> uss = _context.UserStory.Where(x => x.ProjectId == Id).ToList();
                    //for each us in project, delete the us
                    uss.ForEach(a =>
                    {
                        a.IsDeleted = true;
                        a.DateModification = DateTime.UtcNow;
                    });

                    _context.SaveChanges();

                    //End Transaction 
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    resultat = false;
                   //Cancel  all operations if any error
                    transaction.Rollback();
                }
            }
            return resultat;


        }
    }
}

