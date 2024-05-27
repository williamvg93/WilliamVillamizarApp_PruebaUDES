using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.IdUser).HasName("PRIMARY");

        builder.ToTable("users");

        builder.Property(e => e.IdUser).HasColumnName("idUser");
        builder.Property(e => e.DocType)
            .HasMaxLength(40)
            .HasColumnName("docType");
        builder.Property(e => e.Email)
            .HasMaxLength(50)
            .HasColumnName("email");
        builder.Property(e => e.IdenNum).HasColumnName("idenNum");
        builder.Property(e => e.LastName)
            .HasMaxLength(50)
            .HasColumnName("lastName");
        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");
        builder.Property(e => e.Password)
            .HasMaxLength(40)
            .HasColumnName("password");
        builder.Property(e => e.User1)
            .HasMaxLength(40)
            .HasColumnName("user");
    }
}