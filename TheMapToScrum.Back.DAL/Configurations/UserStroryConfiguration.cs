using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.DAL.Configurations
{

    public class UserStroryConfiguration
    {
        public UserStroryConfiguration(EntityTypeBuilder<UserStory> entity)
        {
            entity.HasKey("Id");
            entity.HasOne(v => v.Project)
              .WithMany(a => a.UserStories)
              .HasForeignKey(fk => fk.ProjectId);            

            entity.Property(x => x.Label).HasMaxLength(50).IsRequired();            
        }
    }
}
