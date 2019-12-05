namespace test_data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Competance> competances { get; set; }
        public virtual DbSet<employe> employes { get; set; }
        public virtual DbSet<fichemetier> fichemetiers { get; set; }
        public virtual DbSet<lol> lols { get; set; }
        public virtual DbSet<matricecomp> matricecomps { get; set; }
        public virtual DbSet<niveauxfiche> niveauxfiches { get; set; }
        public virtual DbSet<niveauxmat> niveauxmats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Competance>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<Competance>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Competance>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<Competance>()
                .HasMany(e => e.niveauxmats)
                .WithRequired(e => e.competance)
                .HasForeignKey(e => e.idComp)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Competance>()
                .HasMany(e => e.niveauxfiches)
                .WithRequired(e => e.competance)
                .HasForeignKey(e => e.idComp)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.grade)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<fichemetier>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<fichemetier>()
                .HasMany(e => e.employes)
                .WithOptional(e => e.fichemetier)
                .HasForeignKey(e => e.ficheMetier_Id);

            modelBuilder.Entity<fichemetier>()
                .HasMany(e => e.niveauxfiches)
                .WithRequired(e => e.fichemetier)
                .HasForeignKey(e => e.idFiche)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<lol>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<matricecomp>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<matricecomp>()
                .HasMany(e => e.employes)
                .WithOptional(e => e.matricecomp)
                .HasForeignKey(e => e.matriceComp_Id);

            modelBuilder.Entity<matricecomp>()
                .HasMany(e => e.niveauxmats)
                .WithRequired(e => e.matricecomp)
                .HasForeignKey(e => e.idMat)
                .WillCascadeOnDelete(false);
        }
    }
}
