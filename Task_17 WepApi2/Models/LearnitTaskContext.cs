using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Task_17_WepApi2.Models;

public partial class LearnitTaskContext : DbContext
{
    public LearnitTaskContext()
    {
    }

    public LearnitTaskContext(DbContextOptions<LearnitTaskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<News> News { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-M284REV\\SQLEXPRESS;Database=Learnit_Task;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.Property(e => e.Brief).HasColumnName("brief");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasIndex(e => e.AuthorId, "IX_News_Author_id");

            entity.HasIndex(e => e.CtgId, "IX_News_ctg_id");

            entity.Property(e => e.AuthorId).HasColumnName("Author_id");
            entity.Property(e => e.Brief).HasColumnName("brief");
            entity.Property(e => e.CtgId).HasColumnName("ctg_id");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.News).HasForeignKey(d => d.AuthorId);

            entity.HasOne(d => d.Ctg).WithMany(p => p.News).HasForeignKey(d => d.CtgId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
