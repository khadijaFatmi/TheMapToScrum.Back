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

        public virtual DbSet<UserStory> UserStory { get; set; }
        public virtual DbSet<Project> Project { get; set; }

        public virtual DbSet<ProductOwner> ProductOwner { get; set; }

        public virtual DbSet<ScrumMaster> ScrumMaster { get; set; }

        public virtual DbSet<Team> Team { get; set; }

        public virtual DbSet<Developer> Developer { get; set; }

        public virtual DbSet<Department> Department { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserStroryConfiguration(modelBuilder.Entity<UserStory>());
            new ProjectConfiguration(modelBuilder.Entity<Project>());
            new ProductOwnerConfiguration(modelBuilder.Entity<ProductOwner>());
            new ScrumMasterConfiguration(modelBuilder.Entity<ScrumMaster>());
            new TeamConfiguration(modelBuilder.Entity<Team>());
            new DeveloperConfiguration(modelBuilder.Entity<Developer>());
            new DepartmentConfiguration(modelBuilder.Entity<Department>());


        }
    }
}
