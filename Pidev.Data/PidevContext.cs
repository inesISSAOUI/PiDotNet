namespace Pidev.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Pidev.Domaine.Entities;

   [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]

    public partial class PidevContext : DbContext
    {
        public PidevContext()
            : base("name=PidevContext")
        {
        }

        public virtual DbSet<formateur> formateur { get; set; }
        public virtual DbSet<formation> formation { get; set; }
        public virtual DbSet<planification> planification { get; set; }
        public virtual DbSet<Quiz> Quiz { get; set; }
        public virtual DbSet<Question> Question{ get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<formateur>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<formateur>()
                .Property(e => e.specialite)
                .IsUnicode(false);

            modelBuilder.Entity<formateur>()
                .HasMany(e => e.planification)
                .WithOptional(e => e.formateur)
                .HasForeignKey(e => e.idFormateur);

            modelBuilder.Entity<formation>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.duration)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .Property(e => e.nomFormation)
                .IsUnicode(false);

            modelBuilder.Entity<formation>()
                .HasMany(e => e.planification)
                .WithOptional(e => e.formation)
                .HasForeignKey(e => e.idFormation);

            modelBuilder.Entity<planification>()
                .Property(e => e.dateDebut)
                .IsUnicode(false);

            modelBuilder.Entity<planification>()
                .Property(e => e.dateFin)
                .IsUnicode(false);
        }
    }
}
