using System;
using System.Collections.Generic;
using Corsi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Corsi.Models.Services.Infrastructure;

public partial class MyCourseDbContext : DbContext
{
    public MyCourseDbContext()
    {
    }

    public MyCourseDbContext(DbContextOptions<MyCourseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Data/MyCourse.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Mapping entità Course
        modelBuilder.Entity<Course>(entity =>
        {
            #region Mapping generato automaticamente dal tool di EF
            /*
            entity.HasIndex(e => e.Title, "ux_title").IsUnique();

            entity.Property(e => e.Author).HasColumnType("TEXT (100)");
            entity.Property(e => e.CurrentPriceAmount)
                .HasDefaultValueSql("0")
                .HasColumnType("NUMERIC")
                .HasColumnName("CurrentPrice_Amount");
            entity.Property(e => e.CurrentPriceCurrency)
                .HasDefaultValueSql("'EUR'")
                .HasColumnType("TEXT (3)")
                .HasColumnName("CurrentPrice_Currency");
            entity.Property(e => e.Description).HasColumnType("TEXT (10000)");
            entity.Property(e => e.Email).HasColumnType("TEXT (100)");
            entity.Property(e => e.FullPriceAmount)
                .HasDefaultValueSql("0")
                .HasColumnType("NUMERIC")
                .HasColumnName("FullPrice_Amount");
            entity.Property(e => e.FullPriceCurrency)
                .HasDefaultValueSql("'EUR'")
                .HasColumnType("TEXT (3)")
                .HasColumnName("FullPrice_Currency");
            entity.Property(e => e.ImagePath).HasColumnType("TEXT (100)");
            entity.Property(e => e.RowVersion).HasColumnType("DATETIME");
            entity.Property(e => e.Title).HasColumnType("TEXT (100)");
            */
            #endregion
        
            // Superfluo se la tabella si chiama come il db set messo a disposizione qui
            entity.ToTable("Courses");

            // Superfluo se la proprietà si chiama Id o CoursesId
            entity.HasKey(course => course.Id);

            // Più chiavi in una tabella
            //entity.HasKey(course => new {course.Id, course.Author});
        
            // Mapping per gli owned types
            entity.OwnsOne(course => course.CurrentPrice, builder => {
                builder.Property(money => money.Currency)
                .HasConversion<string>()
                .HasColumnName("CurrentPrice_Currency"); //Superfluo perchè colonna ha lo stesso nome della proprietà
                builder.Property(money => money.Amount).HasColumnName("CurrentPrice_Amount");
            });

            entity.OwnsOne(course => course.FullPrice, builder => {
                builder.Property(money => money.Currency).HasConversion<string>();
            });

            // Mapping per le relazioni
            // 1 : n - 1 Course has many Lessons with a relation to CourdeId
            // Se la proprietà che devo legare si chiama Entità (Course) + Id non serve aggiungere il vincolo
            // in maniera esplicità.
            entity.HasMany(course => course.Lessons)
                  .WithOne(lesson => lesson.Course)
                  .HasForeignKey(lesson => lesson.CourseId);

        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            #region Mapping generato automaticamente dal tool di EF
            /*
            entity.Property(e => e.Description).HasColumnType("TEXT (10000)");
            entity.Property(e => e.Duration)
                .HasDefaultValueSql("'00:00:00'")
                .HasColumnType("TEXT (8)");
            entity.Property(e => e.Title).HasColumnType("TEXT (100)");

            entity.HasOne(d => d.Course).WithMany(p => p.Lessons).HasForeignKey(d => d.CourseId);
            */
            #endregion

            // Lesson, entità che dipende da corsi ma posso fare lo sesso il mapping inverso
            // Fatto già sull'entità course.
            // ATTENZIONE: ne devo fare solo uno non entrambi
            // entity.HasOne(lesson => lesson.Course)
            //       .WithMany(course => course.Lessons);

            
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
