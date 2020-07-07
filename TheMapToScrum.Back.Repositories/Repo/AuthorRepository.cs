using System;
using System.Collections.Generic;
using System.Linq;
using TheMapToScrum.Back.DAL;
using TheMapToScrum.Back.DAL.Entities;
using TheMapToScrum.Back.Repositories.Contract;

namespace TheMapToScrum.Back.Repositories.Repo
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationContext _context;

        public AuthorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Author Create(Author objet)
        {
            _context.Author.Add(objet);
            _context.SaveChanges();
            return objet;
        }

        public Author Get(int id)
        {
            return _context.Author
            .Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Author> GetAll()
        {
            return _context.Author
                .OrderByDescending(x => x.Name)
                .ToList();
        }

        public List<Author> GetAllActive()
        {
            return _context.Author
                .OrderByDescending(x => x.Name)
                .Where(x => !x.IsDeleted)
                .ToList();
        }

        public Author Update(Author entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            return entity;

        }

        //inutilisée (cf suppression logique IsDeleted)
        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }



    }
}
