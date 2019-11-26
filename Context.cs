namespace Data
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

        public virtual DbSet<bonpoint> bonpoint { get; set; }
        public virtual DbSet<employe> employe { get; set; }
        public virtual DbSet<equipe> equipe { get; set; }
        public virtual DbSet<manager> manager { get; set; }
        public virtual DbSet<notification> notification { get; set; }
        public virtual DbSet<reclammation> reclammation { get; set; }
        public virtual DbSet<tache> tache { get; set; }
        public virtual DbSet<timesheet> timesheet { get; set; }
        public virtual DbSet<travailparjour> travailparjour { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<employe>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.bonpoint)
                .WithOptional(e => e.employe)
                .HasForeignKey(e => e.employe_id);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.reclammation)
                .WithOptional(e => e.employe)
                .HasForeignKey(e => e.employe_id);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.notification)
                .WithOptional(e => e.employe)
                .HasForeignKey(e => e.employe_id);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.travailparjour)
                .WithOptional(e => e.employe)
                .HasForeignKey(e => e.employe_id);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.tache)
                .WithOptional(e => e.employe)
                .HasForeignKey(e => e.employe_id);

            modelBuilder.Entity<equipe>()
                .HasMany(e => e.employe)
                .WithOptional(e => e.equipe)
                .HasForeignKey(e => e.equipe_id);

            modelBuilder.Entity<equipe>()
                .HasMany(e => e.manager)
                .WithOptional(e => e.equipe)
                .HasForeignKey(e => e.equipe_id);

            modelBuilder.Entity<manager>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<manager>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<notification>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<reclammation>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<reclammation>()
                .Property(e => e.objet)
                .IsUnicode(false);

            modelBuilder.Entity<tache>()
                .Property(e => e.nom)
                .IsUnicode(false);

            modelBuilder.Entity<timesheet>()
                .Property(e => e.designation)
                .IsUnicode(false);

            modelBuilder.Entity<timesheet>()
                .HasMany(e => e.tache)
                .WithOptional(e => e.timesheet)
                .HasForeignKey(e => e.timesheet_id);

            modelBuilder.Entity<timesheet>()
                .HasMany(e => e.travailparjour)
                .WithOptional(e => e.timesheet)
                .HasForeignKey(e => e.timesheet_id);

            modelBuilder.Entity<travailparjour>()
                .Property(e => e.Jour)
                .IsUnicode(false);
        }
    }
}
