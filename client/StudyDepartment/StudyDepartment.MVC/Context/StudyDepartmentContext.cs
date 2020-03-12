using Microsoft.EntityFrameworkCore;
using StudyDepartment.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyDepartment.Server.Context
{
    public class StudyDepartmentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=studydepartment.sqlite");
        }

        public DbSet<ExamType> ExamTypes { get; set; }
        public DbSet<Jurnal> Jurnals { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudyGroup> StudyGroups { get; set; }
        public DbSet<StudyPlan> StudyPlans { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region SubjectSeed
            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, Name = "Проектирование информационных систем", ShortName = "ПрИС" },
                new Subject { Id = 2, Name = "Системы искусственного интеллекта", ShortName = "СИИ" },
                new Subject { Id = 3, Name = "Программная инженерия", ShortName = "ПИ" },
                new Subject { Id = 4, Name = "Национальная система информационной безопасности", ShortName = "НСИБ" },
                new Subject { Id = 5, Name = "Системный анализ", ShortName = "СисАнал" },
                new Subject { Id = 6, Name = "Распределенные базы данных", ShortName = "РБД" },
                new Subject { Id = 7, Name = "Системное программное обеспечение", ShortName = "СПО" });
            #endregion


            #region ExamTypeSeed
            modelBuilder.Entity<ExamType>().HasData(
                new ExamType { Id = 1, Type = "Экзамен", },
                new ExamType { Id = 2, Type = "Зачет" },
                new ExamType { Id = 3, Type = "Зачет с оценкой" },
                new ExamType { Id = 4, Type = "Курсовая" });
            #endregion

            #region StudyPlanSeed
            modelBuilder.Entity<StudyPlan>().HasData(
                new StudyPlan { Id = 1, SubjectId = 1, ExamTypeId = 1 },
                new StudyPlan { Id = 2, SubjectId = 1, ExamTypeId = 4 },
                new StudyPlan { Id = 3, SubjectId = 2, ExamTypeId = 1 },
                new StudyPlan { Id = 4, SubjectId = 3, ExamTypeId = 1 },
                new StudyPlan { Id = 5, SubjectId = 4, ExamTypeId = 2 },
                new StudyPlan { Id = 6, SubjectId = 5, ExamTypeId = 1 },
                new StudyPlan { Id = 7, SubjectId = 6, ExamTypeId = 2 },
                new StudyPlan { Id = 8, SubjectId = 7, ExamTypeId = 1 });
            #endregion

            #region MarkSeed
            modelBuilder.Entity<Mark>().HasData(
                new Mark { Id = 1, Name = "Отлично", Value = "5" },
                new Mark { Id = 2, Name = "Хорошо", Value = "4" },
                new Mark { Id = 3, Name = "Удовлетворительно", Value = "3" },
                new Mark { Id = 4, Name = "Неудовлетворительно", Value = "2" },
                new Mark { Id = 5, Name = "Зачет", Value = "з" },
                new Mark { Id = 6, Name = "Незачет", Value = "н" },
                new Mark { Id = 7, Name = "НЕявка", Value = "" });
            #endregion
        }
    }
}
