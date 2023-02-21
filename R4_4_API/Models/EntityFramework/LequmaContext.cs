using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace R4_4_API.Models.EntityFramework;

public partial class LequmaContext : DbContext
{
    public LequmaContext()
    {
    }

    public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

    public LequmaContext(DbContextOptions<LequmaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Notation> Avis { get; set; }    

    public virtual DbSet<Film> Films { get; set; }

    public virtual DbSet<Utilisateur> Utilisateurs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseLoggerFactory(MyLoggerFactory)
                .EnableSensitiveDataLogging()
                .UseNpgsql("Server=51.83.36.122; port=5432; Database=lequma; uid=lequma; password=thrzJ1; SearchPath=r41_4;");
            //optionsBuilder.UseLazyLoadingProxies(); // → Utile si chargement des requetes en lazy
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Utilisateur>()
            .Property(b => b.Datecreation)
            .HasDefaultValueSql("current_date");
        modelBuilder.Entity<Utilisateur>().Property(b => b.Pays).HasDefaultValue("France");
        modelBuilder.Entity<Utilisateur>().HasIndex(b => b.Mail).IsUnique();

        modelBuilder.Entity<Notation>(entity =>
        {
            entity.HasKey(n => new { n.Utl_id, n.Flm_id})
                  .HasName("pk_notation");

            entity.HasOne(d => d.FilmNotation)
                  .WithMany(p => p.NotationFilm)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("fk_notation_film");

            entity.HasOne(d => d.UtilisateurNotation)
                  .WithMany(p => p.NotationUtilisateur)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("fk_notation_utilisateur");

            entity.HasCheckConstraint("ck_notation_note", "not_note between 0 and 5");
            
        });

        

        modelBuilder.Entity<Film>(entity =>
        {
            entity.HasKey(e => e.Id)
                  .HasName("pk_film");

            entity.Property(e => e.Id)
                  .HasDefaultValueSql("nextval('film_id_seq'::regclass)");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.Id)
                  .HasName("pk_utilisateur");

            entity.Property(e => e.Id)
                  .HasDefaultValueSql("nextval('utilisateur_id_seq'::regclass)");
            
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}