using Microsoft.EntityFrameworkCore;
using TheMapToScrum.Back.DAL.Configurations;
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
        public virtual DbSet<Project> Project { get; set; }

        public virtual DbSet<BusinessManager> BusinessManager { get; set; }

        public virtual DbSet<TechnicalManager> TechnicalManager { get; set; }

        public virtual DbSet<Team> Team { get; set; }

        public virtual DbSet<Developer> Developer { get; set; }

        public virtual DbSet<Department> Department { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserStroryConfiguration(modelBuilder.Entity<UserStoryContent>());
            new ProjectConfiguration(modelBuilder.Entity<Project>());
            new BusinessManagerConfiguration(modelBuilder.Entity<BusinessManager>());
            new TechnicalManagerConfiguration(modelBuilder.Entity<TechnicalManager>());
            new TeamConfiguration(modelBuilder.Entity<Team>());
            new DeveloperConfiguration(modelBuilder.Entity<Developer>());
            new DepartmentConfiguration(modelBuilder.Entity<Department>());


        }
    }
}
