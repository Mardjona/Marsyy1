using System;
using System.Collections.Generic;
using Marsyy1.Models;
using Microsoft.EntityFrameworkCore;

namespace Marsyy1.Context;

public partial class User735Context : DbContext
{
    public User735Context()
    {
    }

    public User735Context(DbContextOptions<User735Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Visit> Visits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.2.159;Database=user735;Username=user735;password=57667");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_client");

            entity.ToTable("client");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Countofvisit).HasColumnName("countofvisit");
            entity.Property(e => e.Dataofvisit).HasColumnName("dataofvisit");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Photopath)
                .HasMaxLength(1000)
                .HasColumnName("photopath");

            entity.HasOne(d => d.GenderNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.Gender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("client_gender_fk");

            entity.HasMany(d => d.Documents).WithMany(p => p.Clients)
                .UsingEntity<Dictionary<string, object>>(
                    "Documentofclient",
                    r => r.HasOne<Document>().WithMany()
                        .HasForeignKey("DocumentId")
                        .HasConstraintName("documentofclient_document_fk"),
                    l => l.HasOne<Client>().WithMany()
                        .HasForeignKey("Clientid")
                        .HasConstraintName("documentofclient_client_fk"),
                    j =>
                    {
                        j.HasKey("Clientid", "DocumentId").HasName("documentofclient_pk");
                        j.ToTable("documentofclient");
                        j.IndexerProperty<int>("Clientid").HasColumnName("clientid");
                        j.IndexerProperty<int>("DocumentId").HasColumnName("document_id");
                    });

            entity.HasMany(d => d.Tags).WithMany(p => p.Clients)
                .UsingEntity<Dictionary<string, object>>(
                    "Tagofclient",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("Tagid")
                        .HasConstraintName("fk_tagofclient_tag"),
                    l => l.HasOne<Client>().WithMany()
                        .HasForeignKey("Clientid")
                        .HasConstraintName("fk_tagofclient_client"),
                    j =>
                    {
                        j.HasKey("Clientid", "Tagid").HasName("tagofclient_pk");
                        j.ToTable("tagofclient");
                        j.IndexerProperty<int>("Clientid").HasColumnName("clientid");
                        j.IndexerProperty<int>("Tagid").HasColumnName("tagid");
                    });
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("document_pk");

            entity.ToTable("document");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Documentpath)
                .HasColumnType("character varying")
                .HasColumnName("documentpath");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("gender_pk");

            entity.ToTable("gender");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_tag");

            entity.ToTable("tag");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Color)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("color");
            entity.Property(e => e.Title)
                .HasMaxLength(30)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Visit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("visit_pk");

            entity.ToTable("visit");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Lastdate).HasColumnName("lastdate");

            entity.HasOne(d => d.Client).WithMany(p => p.Visits)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("visit_client_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
