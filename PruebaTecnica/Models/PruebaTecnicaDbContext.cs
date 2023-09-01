using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnica.Models;

public partial class PruebaTecnicaDbContext : DbContext
{
    public PruebaTecnicaDbContext()
    {
    }

    public PruebaTecnicaDbContext(DbContextOptions<PruebaTecnicaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Solicitude> Solicitudes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=localhost;Database=PruebaTecnicaDB;integrated security=True; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__departam__787A433D9DBE5E9A");

            entity.ToTable("departamentos");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Solicitude>(entity =>
        {
            entity.HasKey(e => e.IdSolicitud).HasName("PK__solicitu__36899CEF3B22AB74");

            entity.ToTable("solicitudes");

            entity.Property(e => e.Application)
                .HasMaxLength(50)
                .HasColumnName("application");
            entity.Property(e => e.Departament)
                .HasMaxLength(50)
                .HasColumnName("departament");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.FinalDate)
                .HasColumnType("date")
                .HasColumnName("finalDate");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("startDate");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuarios__5B65BF9710E7FCC4");

            entity.ToTable("usuarios");

            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .HasColumnName("pass");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Tipo)
                .HasMaxLength(25)
                .HasDefaultValueSql("('empleado')")
                .HasColumnName("tipo");

            entity.HasOne(d => d.ObDepartamento).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK__usuarios__IdDepa__59063A47");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
