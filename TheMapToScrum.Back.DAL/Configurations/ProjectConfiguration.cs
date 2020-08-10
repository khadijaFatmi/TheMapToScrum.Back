using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.DAL.Configurations
{
    public class ProjectConfiguration
    {
        public ProjectConfiguration(EntityTypeBuilder<Project> entity)
        {
            entity.HasKey("Id");
            entity.Property(x => x.Label).HasMaxLength(int.MaxValue).IsRequired();
        }
    }
}
