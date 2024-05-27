using System;
using System.Collections.Generic;
using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Persistence.Data;

public partial class ApiUdesContext : DbContext
{
    public ApiUdesContext()
    {
    }

    public ApiUdesContext(DbContextOptions<ApiUdesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

    /*     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseMySql("server=localhost;user=root;password=admin;database=udes", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.37-mysql")); */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        /* modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Role>(entity =>
        {
            
        });

        modelBuilder.Entity<User>(entity =>
        {
            
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            
        });

        OnModelCreatingPartial(modelBuilder); */
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
