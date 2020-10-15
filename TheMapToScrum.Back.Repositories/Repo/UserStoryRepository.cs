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

    public List<UserStory> getByProjectId(int id)
    {
      string strSql = "SELECT us.Id, us.ProjectId,us.[Version],us.[Label],us.[Role],us.Function1,us.Function2,us.Notes,us.[Priority],us.StoryPoints";
      strSql += ",us.EpicStory,us.UsStatus,us.IsDeleted,us.DateCreation ,us.DateModification, count(t.id) as nbTasks FROM UserStory us";
      strSql += " LEFT Join Taask t ON t.UserStoryId = us.Id Group By us.Id,us.ProjectId,us.[Version],us.[Label],us.[Role],us.Function1,us.Function2";
      strSql += " ,us.Notes ,us.[Priority],us.StoryPoints ,us.EpicStory,us.UsStatus,us.IsDeleted,us.DateCreation,us.DateModification";



      List<UserStory> retour = _context.UserStory.FromSqlRaw(strSql)
          .Include(p => p.Project)
          .ThenInclude(d => d.Department)
          .Include(p => p.Project)
          .ThenInclude(po => po.ProductOwner)
          .Include(p => p.Project)
          .ThenInclude(sm => sm.ScrumMaster)
          .Include(p => p.Project)
          .ThenInclude(t => t.Team)
          .Where(x => x.ProjectId == id).ToList();

      return retour;
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
      string strSql = "SELECT us.Id, us.ProjectId,us.[Version],us.[Label],us.[Role],us.Function1,us.Function2,us.Notes,us.[Priority],us.StoryPoints";
      strSql += ",us.EpicStory,us.UsStatus,us.IsDeleted,us.DateCreation ,us.DateModification, count(t.id) as nbTasks FROM UserStory us";
      strSql += " LEFT Join Taask t ON t.UserStoryId = us.Id Group By us.Id,us.ProjectId,us.[Version],us.[Label],us.[Role],us.Function1,us.Function2";
      strSql += " ,us.Notes ,us.[Priority],us.StoryPoints ,us.EpicStory,us.UsStatus,us.IsDeleted,us.DateCreation,us.DateModification";

     

      UserStory retour = _context.UserStory.FromSqlRaw(strSql)
          .Include(p => p.Project)
          .ThenInclude(d => d.Department)
          .Include(p => p.Project)
          .ThenInclude(po => po.ProductOwner)
          .Include(p => p.Project)
          .ThenInclude(sm => sm.ScrumMaster)
          .Include(p => p.Project)
          .ThenInclude(t => t.Team)
          .Where(x => x.Id == Id).FirstOrDefault();

      return retour;
    }

    public List<UserStory> GetAll()
    {
      string strSql = "SELECT us.Id, us.ProjectId,us.[Version],us.[Label],us.[Role],us.Function1,us.Function2,us.Notes,us.[Priority],us.StoryPoints";
      strSql += ",us.EpicStory,us.UsStatus,us.IsDeleted,us.DateCreation ,us.DateModification, count(t.id) as nbTasks FROM UserStory us";
      strSql += " LEFT Join Taask t ON t.UserStoryId = us.Id Group By us.Id,us.ProjectId,us.[Version],us.[Label],us.[Role],us.Function1,us.Function2";
      strSql += " ,us.Notes ,us.[Priority],us.StoryPoints ,us.EpicStory,us.UsStatus,us.IsDeleted,us.DateCreation,us.DateModification";


      return _context.UserStory.FromSqlRaw(strSql)
      .Include(p => p.Project)
      .OrderByDescending(x => x.Label)
       .ToList();

      //List<UserStory> result = from us in _context.UserStory
      //                         join T in _context.Taask on us.Id equals T.UserStoryId into g
      //                         select(x => new UserStory()
      //                         {
      //                             //DateCreation = x.,
      //                             //Id: x.Id,
      //                             //Version = x.Version,
      //                             //Label = x.Label,
      //                             //Role = x.Role,

      //                             //Priority = x.Priority,
      //                             //DateCreation = (System.DateTime)x.DateCreation,
      //                             //DateModification = (System.DateTime)x.DateModification,
      //                             //EpicStory = x.EpicStory,
      //                             //usStatus = x.usStatus,
      //                             ////strUsStatus = x.
      //                             //StoryPoints = x.StoryPoints,
      //                             //Function1 = x.Function1,
      //                             //Function2 = x.Function2,
      //                             //Notes = x.Notes,
      //                             //IsDeleted = x.IsDeleted,
      //                             //ProjectId = x.ProjectId,
      //                             //nbTasks = g.Count(a => a.UserStoryId == us.Id),

      //                         //}).ToList();

      //return result;
    }

    public List<UserStory> GetAllActive()
    {
      string strSql = "SELECT us.Id, us.ProjectId,us.[Version],us.[Label],us.[Role],us.Function1,us.Function2,us.Notes,us.[Priority],us.StoryPoints";
      strSql += ",us.EpicStory,us.UsStatus,us.IsDeleted,us.DateCreation ,us.DateModification, count(t.id) as nbTasks FROM UserStory us";
      strSql += " LEFT Join Taask t ON t.UserStoryId = us.Id Group By us.Id,us.ProjectId,us.[Version],us.[Label],us.[Role],us.Function1,us.Function2";
      strSql += " ,us.Notes ,us.[Priority],us.StoryPoints ,us.EpicStory,us.UsStatus,us.IsDeleted,us.DateCreation,us.DateModification";

      return _context.UserStory.FromSqlRaw(strSql)
                .Include(p => p.Project)
                .OrderByDescending(x => x.Label)
                .Where(x => (bool)!x.IsDeleted)
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
