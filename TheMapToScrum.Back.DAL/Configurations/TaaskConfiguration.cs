using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.DAL.Configurations
{
    public class TaaskConfiguration
    {
        public TaaskConfiguration(EntityTypeBuilder<Taask> entity)
        {
            entity.HasKey("Id");
            //entity.HasOne(v => v.UserStory);
              //.WithMany(a => a.Taasks)
              //.HasForeignKey(fk => fk.UserStoryId);

            entity.Property(x => x.Label).HasMaxLength(50).IsRequired();
        }
    }
}