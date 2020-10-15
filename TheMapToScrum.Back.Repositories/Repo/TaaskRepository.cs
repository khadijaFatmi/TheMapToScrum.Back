using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.Repositories.Repo
{
  public class TaaskRepository : ITaaskRepository
  {
    private readonly ApplicationContext _context;

    public TaaskRepository(ApplicationContext context)
    {
      _context = context;
    }

    public Taask Create(Taask obj)
    {
      _context.Taask.Add(obj);
      _context.SaveChanges();
      return obj;

    }


    public Taask Get(int Id)
    {
      Taask retour = _context.Taask
          .Where(x => x.Id == Id).FirstOrDefault();
      return retour;
    }


    public List<Taask> GetAll()
    {
      return _context.Taask
          //.Include(p => p.Project)
          .OrderByDescending(x => x.Label)
          .ToList();

    }


    public List<Taask> GetAllActive()
    {
      List<Taask> retour = _context.Taask
                .Include(p => p.UserStory)
                .OrderByDescending(x => x.Label)
                .Where(x => (bool) !x.IsDeleted)
                .ToList();
      return retour;
    }

    public List<Taask>GetByUsId(int Id)
    {
      List<Taask> result = _context.Taask
                  .Include(us => us.UserStory)
                  .Include(dvp => dvp.Developer)
                  .Include(p => p.Project)
                  .ThenInclude(d => d.Department)

                  .Where(i => i.UserStoryId == Id && i.IsDeleted != true)
                  .ToList();
      return result;
    }
    public List<Taask> GetByProjectId(int Id)
    {
      List<Taask> result = _context.Taask
                  .Include(dvp => dvp.Developer)
                  .Include(us => us.UserStory)
                  .Include(p => p.Project)
                  .ThenInclude(d => d.Department)
                  .Where(i => i.ProjectId == Id && i.IsDeleted != true)
                  .ToList();
      return result;
    }


    public Taask Update(Taask entity)
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
        // select * from
        Taask entite = _context.Taask.Where(x => x.Id == Id).First();
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

    public int GetNextNumberByUsId(int userStoryId)
    {
      List<Taask> tasks = _context.Taask.Where(x => x.UserStoryId == userStoryId).ToList();
      int nextnumberByUs = tasks.Count + 1;
      return nextnumberByUs;

    }

    public int GetNextNumberByProjectId(int projectId)
    {
      List<Taask> tasksP = _context.Taask.Where(x => x.ProjectId == projectId && x.UserStoryId == null).ToList();
      int nextnumberByProject = tasksP.Count;
      List<Taask> tasksU = _context.Taask.Where(x => x.UserStoryId != null).ToList();
      int retour = tasksU.Count + nextnumberByProject;

      return retour;

    }

  } 
}
