using System.IO;
using BlazorApp1.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Server.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext()
    {
    }
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Shared.Models.Client> Clients { get; set; } = null!;
    public virtual DbSet<Shared.Models.Student> Students { get; set; } = null!;
    public virtual DbSet<Shared.Models.Parent> Parents { get; set; } = null!;
    public virtual DbSet<Shared.Models.Teacher> Teachers { get; set; } = null!;


    //public DbSet<Shared.Models.FileModel> Files { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shared.Models.Client>(entity =>
        {
            entity.ToTable("clientdetails");
            entity.Property(e => e.ClientId).HasColumnName("ClientId");
            entity.Property(e => e.ClientName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CellNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });
        modelBuilder.Entity<Shared.Models.Teacher>(entity =>
        {
            entity.ToTable("teacherdetails");
            entity.Property(e => e.ClientId).HasColumnName("ClientId");
            entity.Property(e => e.ClientName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CellNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });
        modelBuilder.Entity<Shared.Models.Parent>(entity =>
        {
            entity.ToTable("parentdetails");
            entity.Property(e => e.ClientId).HasColumnName("ClientId");
            entity.Property(e => e.ClientName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CellNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });
        modelBuilder.Entity<Shared.Models.Student>(entity =>
        {
            entity.ToTable("studentdetails");
            entity.Property(e => e.ClientId).HasColumnName("ClientId");
            entity.Property(e => e.ClientName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CellNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });
        modelBuilder.Entity<Student>()
            .HasMany(t => t.Teachers)
            .WithMany(b => b.Students);
        modelBuilder.Entity<Student>()
            .HasMany(t => t.Parents)
            .WithMany(b => b.Childs);
        /*modelBuilder.Entity<Shared.Models.Student>(entity =>
        {
            entity.HasMany(t => t.Teachers).WithMany(b => b.Students);
        });

        modelBuilder.Entity<Student>()
            .HasMany(t => t.Teachers)
            .WithMany(b => b.Students);
        modelBuilder.Entity<Student>()
            .HasMany(t => t.Parents)
            .WithMany(b => b.Childs);*/


        OnModelCreatingPartial(modelBuilder);
    }
    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shared.Models.Client>(entity =>
        {
            entity.ToTable("clientdetails");
            entity.Property(e => e.ClientId).HasColumnName("ClientId");
            entity.Property(e => e.ClientName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CellNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
        });
        OnModelCreatingPartial(modelBuilder);
    }*/
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}