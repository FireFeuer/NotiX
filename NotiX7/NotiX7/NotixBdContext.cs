using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NotiX7;

public partial class NotixBdContext : DbContext
{
    public NotixBdContext()
    {
    }

    public NotixBdContext(DbContextOptions<NotixBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ColorsCategory> ColorsCategories { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source= notixBD.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ColorsCategory>(entity =>
        {
            entity.HasKey(e => e.ColorsInt);

            entity.ToTable("colors_categories");

            entity.Property(e => e.ColorsInt)
                .ValueGeneratedNever()
                .HasColumnName("colors_int");
            entity.Property(e => e.ColorsTxt).HasColumnName("colors_txt");
            entity.Property(e => e.Hex).HasColumnName("hex");
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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
