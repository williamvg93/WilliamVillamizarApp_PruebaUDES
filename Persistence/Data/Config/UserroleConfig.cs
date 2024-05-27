using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config;

public class UserroleConfig : IEntityTypeConfiguration<Userrole>
{
    public void Configure(EntityTypeBuilder<Userrole> builder)
    {
        builder.HasKey(e => e.IdUserRol).HasName("PRIMARY");

        builder.ToTable("userroles");

        builder.HasIndex(e => e.FkIdRol, "FK_IdRol");

        builder.HasIndex(e => e.FkIdUser, "FK_idUser");

        builder.Property(e => e.IdUserRol).HasColumnName("idUserRol");
        builder.Property(e => e.FkIdRol).HasColumnName("fkIdRol");
        builder.Property(e => e.FkIdUser).HasColumnName("fkIdUser");

        builder.HasOne(d => d.FkIdRolNavigation).WithMany(p => p.Userroles)
            .HasForeignKey(d => d.FkIdRol)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_IdRol");

        builder.HasOne(d => d.FkIdUserNavigation).WithMany(p => p.Userroles)
            .HasForeignKey(d => d.FkIdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_idUser");
    }
}