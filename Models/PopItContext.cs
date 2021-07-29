using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PopIt.Models
{
    public partial class PopItContext : DbContext
    {
        public PopItContext()
        {
        }

        public PopItContext(DbContextOptions<PopItContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminLogin> AdminLogins { get; set; }
        public virtual DbSet<AdminMapping> AdminMappings { get; set; }
        public virtual DbSet<ClassroomStudent> ClassroomStudents { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<StudentDetail> StudentDetails { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<TeacherDetail> TeacherDetails { get; set; }
        public virtual DbSet<TestDetail> TestDetails { get; set; }
        public virtual DbSet<TestRule> TestRules { get; set; }
        public virtual DbSet<UserCategory> UserCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ASPLAPR378;Database=PopIt;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdminLogin>(entity =>
            {
                entity.HasKey(e => e.AdminNo);

                entity.ToTable("AdminLogin");

                entity.Property(e => e.AdminNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.AdminLogins)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminLogin_UserCategory");
            });

            modelBuilder.Entity<AdminMapping>(entity =>
            {
                entity.HasKey(e => e.AdminId)
                    .HasName("PK_Classroom");

                entity.ToTable("AdminMapping");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.AdminMappings)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Classroom_Grade");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.AdminMappings)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdminMapping_Subjects");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.AdminMappings)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Classroom_TeacherDetails");
            });

            modelBuilder.Entity<ClassroomStudent>(entity =>
            {
                entity.HasKey(e => e.Stdid);

                entity.ToTable("Classroom_Student");

                entity.Property(e => e.Stdid).ValueGeneratedNever();
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.Property(e => e.GradeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grade_StudentDetails");
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialId).ValueGeneratedOnAdd();

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.QuestionNumber);

                entity.HasComment("");

                entity.Property(e => e.Answer).HasColumnName("answer");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("description");

                entity.Property(e => e.Mark).HasColumnName("mark");

                entity.Property(e => e.Option1)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("option1");

                entity.Property(e => e.Option2)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("option2");

                entity.Property(e => e.Option3)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("option3");

                entity.Property(e => e.Option4)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("option4");

                entity.Property(e => e.Question1)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("question");

                entity.Property(e => e.Uploads)
                    .HasColumnType("text")
                    .HasColumnName("uploads");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK_Questions_TestDetails");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_Questions_Subjects");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Results_TestDetails");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Results_StudentDetails");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Results_Results");
            });

            modelBuilder.Entity<StudentDetail>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("DOB");

                entity.Property(e => e.Emailid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastlogin).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RollNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.StudentDetails)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentDetails_UserCategory");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.SubjectId).ValueGeneratedNever();

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subjects_Grade");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subjects_TeacherDetails");
            });

            modelBuilder.Entity<TeacherDetail>(entity =>
            {
                entity.HasKey(e => e.TeacherId)
                    .HasName("PK_StaffDetails");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Emailid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Experience)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lastlogin).HasColumnType("datetime");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StaffNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TeacherDetails)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffDetails_StaffDetails");
            });

            modelBuilder.Entity<TestDetail>(entity =>
            {
                entity.HasKey(e => e.ExamId);

                entity.Property(e => e.ExamId).ValueGeneratedNever();

                entity.Property(e => e.Examname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.TestDetails)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestDetails_Grade");

                entity.HasOne(d => d.GradeNavigation)
                    .WithMany(p => p.TestDetails)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestDetails_TestRules");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TestDetails)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TestDetails_Subjects");
            });

            modelBuilder.Entity<TestRule>(entity =>
            {
                entity.HasKey(e => e.Grade);

                entity.Property(e => e.Grade).ValueGeneratedNever();

                entity.Property(e => e.Examduration).HasColumnName("examduration");

                entity.Property(e => e.Passmarkss).HasColumnName("passmarkss");

                entity.Property(e => e.Rules)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("rules");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Subjectname)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("subjectname");

                entity.Property(e => e.Totalmarks).HasColumnName("totalmarks");
            });

            modelBuilder.Entity<UserCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("UserCategory");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
