﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TheMapToScrum.Back.DAL.Entities;

namespace TheMapToScrum.Back.DAL.Configurations
{
    public class BusinessManagerConfiguration
    {
        public BusinessManagerConfiguration(EntityTypeBuilder<BusinessManager> entity)
        {
            
            entity.HasKey("Id");
            entity.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            entity.Property(x => x.LastName).HasMaxLength(50).IsRequired();
        }
    }
}
