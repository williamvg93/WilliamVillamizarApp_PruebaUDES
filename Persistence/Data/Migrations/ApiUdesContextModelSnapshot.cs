﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Data;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(ApiUdesContext))]
    partial class ApiUdesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idRol");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("IdRol")
                        .HasName("PRIMARY");

                    b.ToTable("roles", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idUser");

                    b.Property<string>("DocType")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("docType");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<int>("IdenNum")
                        .HasColumnType("int")
                        .HasColumnName("idenNum");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("lastName");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("password");

                    b.Property<string>("User1")
                        .HasMaxLength(40)
                        .HasColumnType("varchar(40)")
                        .HasColumnName("user");

                    b.HasKey("IdUser")
                        .HasName("PRIMARY");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Userrole", b =>
                {
                    b.Property<int>("IdUserRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idUserRol");

                    b.Property<int>("FkIdRol")
                        .HasColumnType("int")
                        .HasColumnName("fkIdRol");

                    b.Property<int>("FkIdUser")
                        .HasColumnType("int")
                        .HasColumnName("fkIdUser");

                    b.HasKey("IdUserRol")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "FkIdRol" }, "FK_IdRol");

                    b.HasIndex(new[] { "FkIdUser" }, "FK_idUser");

                    b.ToTable("userroles", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Userrole", b =>
                {
                    b.HasOne("Domain.Entities.Role", "FkIdRolNavigation")
                        .WithMany("Userroles")
                        .HasForeignKey("FkIdRol")
                        .IsRequired()
                        .HasConstraintName("FK_IdRol");

                    b.HasOne("Domain.Entities.User", "FkIdUserNavigation")
                        .WithMany("Userroles")
                        .HasForeignKey("FkIdUser")
                        .IsRequired()
                        .HasConstraintName("FK_idUser");

                    b.Navigation("FkIdRolNavigation");

                    b.Navigation("FkIdUserNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Role", b =>
                {
                    b.Navigation("Userroles");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Userroles");
                });
#pragma warning restore 612, 618
        }
    }
}
