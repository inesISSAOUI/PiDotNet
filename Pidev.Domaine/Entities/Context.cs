namespace Domain.Entities
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

        public virtual DbSet<assessment> assessment { get; set; }
        public virtual DbSet<assessment360> assessment360 { get; set; }
        public virtual DbSet<assessmentdone360> assessmentdone360 { get; set; }
        public virtual DbSet<assessmentself> assessmentself { get; set; }
        public virtual DbSet<criteria> criteria { get; set; }
        public virtual DbSet<criteriascore> criteriascore { get; set; }
        public virtual DbSet<criteriascoreself> criteriascoreself { get; set; }
        public virtual DbSet<employee> employee { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<assessment>()
                .Property(e => e.resultAssesment)
                .IsUnicode(false);

            modelBuilder.Entity<assessment>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<assessment>()
                .HasMany(e => e.assessmentself)
                .WithOptional(e => e.assessment)
                .HasForeignKey(e => e.assessment_idAssessment);

            modelBuilder.Entity<assessment>()
                .HasMany(e => e.assessment360)
                .WithOptional(e => e.assessment)
                .HasForeignKey(e => e.assessment_idAssessment);

            modelBuilder.Entity<assessment360>()
                .HasMany(e => e.assessmentdone360)
                .WithOptional(e => e.assessment360)
                .HasForeignKey(e => e.assessment360_id360);

            modelBuilder.Entity<assessmentdone360>()
                .HasMany(e => e.criteriascore)
                .WithOptional(e => e.assessmentdone360)
                .HasForeignKey(e => e.assessmentDone_idDone360);

            modelBuilder.Entity<assessmentself>()
                .HasMany(e => e.criteriascoreself)
                .WithOptional(e => e.assessmentself)
                .HasForeignKey(e => e.assessmentSelfDone_idSelf);

            modelBuilder.Entity<criteria>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<criteria>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<criteria>()
                .HasMany(e => e.criteriascore)
                .WithOptional(e => e.criteria)
                .HasForeignKey(e => e.criteria_idCriteria);

            modelBuilder.Entity<criteria>()
                .HasMany(e => e.criteriascoreself)
                .WithOptional(e => e.criteria)
                .HasForeignKey(e => e.criteria_idCriteria);

            modelBuilder.Entity<criteriascore>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<criteriascoreself>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.assessment)
                .WithOptional(e => e.employee)
                .HasForeignKey(e => e.employee_idEmployee);

            modelBuilder.Entity<employee>()
                .HasMany(e => e.assessmentdone360)
                .WithOptional(e => e.employee)
                .HasForeignKey(e => e.coWorker_idEmployee);
        }
    }
}
