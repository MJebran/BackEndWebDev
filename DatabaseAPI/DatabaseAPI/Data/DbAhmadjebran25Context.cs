using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI.Data;

public partial class DbAhmadjebran25Context : DbContext
{
    public DbAhmadjebran25Context()
    {
    }

    public DbAhmadjebran25Context(DbContextOptions<DbAhmadjebran25Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Audience> Audiences { get; set; }

    public virtual DbSet<Audiencecategory> Audiencecategories { get; set; }

    public virtual DbSet<Categorizedaudience> Categorizedaudiences { get; set; }

    public virtual DbSet<Categorizedjoke> Categorizedjokes { get; set; }

    public virtual DbSet<Deliveredjoke> Deliveredjokes { get; set; }

    public virtual DbSet<Joke> Jokes { get; set; }

    public virtual DbSet<Jokecategory> Jokecategories { get; set; }

    public virtual DbSet<Jokereactioncategory> Jokereactioncategories { get; set; }

    public virtual DbSet<PoLine> PoLines { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Supply> Supplies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:JokeDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Audience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("audience_pkey");

            entity.ToTable("audience", "dad_jokes");

            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Audiencename)
                .HasMaxLength(100)
                .HasColumnName("audiencename");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<Audiencecategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("audiencecategory_pkey");

            entity.ToTable("audiencecategory", "dad_jokes");

            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(100)
                .HasColumnName("categoryname");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<Categorizedaudience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categorizedaudience_pkey");

            entity.ToTable("categorizedaudience", "dad_jokes");

            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Audiencecategoryid)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("audiencecategoryid");
            entity.Property(e => e.Audienceid)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("audienceid");

            entity.HasOne(d => d.Audiencecategory).WithMany(p => p.Categorizedaudiences)
                .HasForeignKey(d => d.Audiencecategoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categorizedaudience_audiencecategoryid_fkey");

            entity.HasOne(d => d.Audience).WithMany(p => p.Categorizedaudiences)
                .HasForeignKey(d => d.Audienceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categorizedaudience_audienceid_fkey");
        });

        modelBuilder.Entity<Categorizedjoke>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categorizedjoke_pkey");

            entity.ToTable("categorizedjoke", "dad_jokes");

            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Jokecategoryid)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("jokecategoryid");
            entity.Property(e => e.Jokeid)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("jokeid");

            entity.HasOne(d => d.Jokecategory).WithMany(p => p.Categorizedjokes)
                .HasForeignKey(d => d.Jokecategoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categorizedjoke_jokecategoryid_fkey");

            entity.HasOne(d => d.Joke).WithMany(p => p.Categorizedjokes)
                .HasForeignKey(d => d.Jokeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categorizedjoke_jokeid_fkey");
        });

        modelBuilder.Entity<Deliveredjoke>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("deliveredjoke_pkey");

            entity.ToTable("deliveredjoke", "dad_jokes");

            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Audienceid)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("audienceid");
            entity.Property(e => e.Delivereddate).HasColumnName("delivereddate");
            entity.Property(e => e.Jokeid)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("jokeid");
            entity.Property(e => e.Jokereactionid)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("jokereactionid");
            entity.Property(e => e.Notes).HasColumnName("notes");

            entity.HasOne(d => d.Audience).WithMany(p => p.Deliveredjokes)
                .HasForeignKey(d => d.Audienceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deliveredjoke_audienceid_fkey");

            entity.HasOne(d => d.Joke).WithMany(p => p.Deliveredjokes)
                .HasForeignKey(d => d.Jokeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deliveredjoke_jokeid_fkey");

            entity.HasOne(d => d.Jokereaction).WithMany(p => p.Deliveredjokes)
                .HasForeignKey(d => d.Jokereactionid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deliveredjoke_jokereactionid_fkey");
        });

        modelBuilder.Entity<Joke>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("joke_pkey");

            entity.ToTable("joke", "dad_jokes");

            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Jokename)
                .HasMaxLength(255)
                .HasColumnName("jokename");
            entity.Property(e => e.Joketext).HasColumnName("joketext");
        });

        modelBuilder.Entity<Jokecategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jokecategory_pkey");

            entity.ToTable("jokecategory", "dad_jokes");

            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(100)
                .HasColumnName("categoryname");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<Jokereactioncategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jokereactioncategory_pkey");

            entity.ToTable("jokereactioncategory", "dad_jokes");

            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("id");
            entity.Property(e => e.Descriptoin).HasColumnName("descriptoin");
            entity.Property(e => e.Reactionlevel)
                .HasMaxLength(100)
                .HasColumnName("reactionlevel");
        });

        modelBuilder.Entity<PoLine>(entity =>
        {
            entity.HasKey(e => new { e.Ponr, e.Prodnr }).HasName("po_line_pkey");

            entity.ToTable("po_line");

            entity.Property(e => e.Ponr)
                .HasMaxLength(7)
                .IsFixedLength()
                .HasColumnName("ponr");
            entity.Property(e => e.Prodnr)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("prodnr");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.PonrNavigation).WithMany(p => p.PoLines)
                .HasForeignKey(d => d.Ponr)
                .HasConstraintName("po_line_ponr_fkey");

            entity.HasOne(d => d.ProdnrNavigation).WithMany(p => p.PoLines)
                .HasForeignKey(d => d.Prodnr)
                .HasConstraintName("po_line_prodnr_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Prodnr).HasName("product_pkey");

            entity.ToTable("product");

            entity.HasIndex(e => e.Prodname, "uci").IsUnique();

            entity.Property(e => e.Prodnr)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("prodnr");
            entity.Property(e => e.AvailableQuantity).HasColumnName("available_quantity");
            entity.Property(e => e.Prodname)
                .HasMaxLength(60)
                .HasColumnName("prodname");
            entity.Property(e => e.Prodtype)
                .HasMaxLength(10)
                .HasColumnName("prodtype");
        });

        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.HasKey(e => e.Ponr).HasName("purchase_order_pkey");

            entity.ToTable("purchase_order");

            entity.Property(e => e.Ponr)
                .HasMaxLength(7)
                .IsFixedLength()
                .HasColumnName("ponr");
            entity.Property(e => e.Podate).HasColumnName("podate");
            entity.Property(e => e.Supnr)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("supnr");

            entity.HasOne(d => d.SupnrNavigation).WithMany(p => p.PurchaseOrders)
                .HasForeignKey(d => d.Supnr)
                .HasConstraintName("purchase_order_supnr_fkey");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Supnr).HasName("supplier_pkey");

            entity.ToTable("supplier");

            entity.Property(e => e.Supnr)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("supnr");
            entity.Property(e => e.Supaddress)
                .HasMaxLength(50)
                .HasColumnName("supaddress");
            entity.Property(e => e.Supcity)
                .HasMaxLength(20)
                .HasColumnName("supcity");
            entity.Property(e => e.Supname)
                .HasMaxLength(40)
                .HasColumnName("supname");
            entity.Property(e => e.Supstatus).HasColumnName("supstatus");
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => new { e.Supnr, e.Prodnr }).HasName("supplies_pkey");

            entity.ToTable("supplies");

            entity.Property(e => e.Supnr)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("supnr");
            entity.Property(e => e.Prodnr)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("prodnr");
            entity.Property(e => e.DelivPeriod)
                .HasComment("deliv_period in days")
                .HasColumnName("deliv_period");
            entity.Property(e => e.PurchasePrice)
                .HasComment("purchase_price in eur")
                .HasColumnName("purchase_price");

            entity.HasOne(d => d.ProdnrNavigation).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.Prodnr)
                .HasConstraintName("supplies_prodnr_fkey");

            entity.HasOne(d => d.SupnrNavigation).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.Supnr)
                .HasConstraintName("supplies_supnr_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
