using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.Repositories.Repo
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationContext _context;


        public DepartmentRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Department Create(Department objet)
        {
            _context.Department.Add(objet);
            _context.SaveChanges();
            return objet;
        }

        public Department Get(int Id)
        {
            return _context.Department
                .Where(x => x.Id == Id).FirstOrDefault();

        }

        public List<Department> GetAll()
        {
            return _context.Department
                .OrderByDescending(x => x.Label)
                .ToList();
        }

        public List<Department> GetAllActive()
        {
            return _context.Department
                .OrderByDescending(x => x.Label)
                .Where(x => !x.IsDeleted)
                .ToList();
        }

        public Department Update(Department entity)
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
                Department entite = _context.Department.Where(x => x.Id == Id).First();
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
