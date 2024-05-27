using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config;

public class RoleConfig : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(e => e.IdRol).HasName("PRIMARY");

        builder.ToTable("roles");

        builder.Property(e => e.IdRol).HasColumnName("idRol");
        builder.Property(e => e.Description).HasMaxLength(150);
        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");
    }
}