using Microsoft.EntityFrameworkCore;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.DAL

{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() 
        { }

        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option) 
        {

        }

        public virtual DbSet<UserStoryContent> UserStoryContent { get; set; }
        public virtual DbSet<Projet> Projet { get; set; }

        public virtual DbSet<Author> Author { get; set; }

        public virtual DbSet<Developer> Developer { get; set; }

        public virtual DbSet<Pole> Pole { get; set; }



    }
}
