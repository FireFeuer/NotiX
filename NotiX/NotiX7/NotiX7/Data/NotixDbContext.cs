using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NotiX7.Data.DbEntities;

namespace NotiX7.Data;

public partial class NotixDbContext : DbContext
{
    public NotixDbContext()
    {
    }

    public NotixDbContext(DbContextOptions<NotixDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ColorsCategory> ColorsCategories { get; set; }

    public virtual DbSet<Note> Notes { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("DataSource=Assets/Databases/NotixDB.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ColorsCategory>(entity =>
        {
            entity.ToTable("colors_categories");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Hex).HasColumnName("hex");
            entity.Property(e => e.Text).HasColumnName("text");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.ToTable("note");

            entity.HasIndex(e => e.Id, "IX_note_ID").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Color).HasColumnName("color");
            entity.Property(e => e.FirstDate).HasColumnName("first_date");
            entity.Property(e => e.SecondDate).HasColumnName("second_date");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.Text).HasColumnName("text");
            entity.Property(e => e.Title).HasColumnName("title");
            entity.Property(e => e.X).HasColumnName("x");
            entity.Property(e => e.Y).HasColumnName("y");

            entity.HasOne(d => d.ColorNavigation).WithMany(p => p.Notes)
                .HasForeignKey(d => d.Color)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
