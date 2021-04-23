using Microsoft.EntityFrameworkCore;
using System;

namespace ApiForMedicalSystem.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> UserItem { get; set; }
        public DbSet<Disease> DiseaseItem { get; set; }
        public DbSet<Test> TestItem { get; set; }
        public DbSet<Symptom> SymptomItem { get; set; }
        public DbSet<AnswerUser> AnswerUserItem { get; set; }
        public DbSet<Coefficient> CoefficientItem { get; set; }
        public DbSet<Result> ResultItem { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User { Id = Convert.ToInt64(1), Age = 22, BMI = 80, Gender = "female", Height = 170, Weight = 70, Login = "user1",Password = "user1"});
            modelBuilder.Entity<User>().HasData(new User { Id = Convert.ToInt64(2), Age = 30, BMI = 100, Gender = "male", Height = 180, Weight = 90, Login = "user2", Password = "user2" });

            modelBuilder.Entity<Test>().HasData(new Test { Id = 1, UserId = Convert.ToInt64(1) });
            modelBuilder.Entity<Test>().HasData(new Test { Id = 2, UserId = Convert.ToInt64(1) });
            modelBuilder.Entity<Test>().HasData(new Test { Id = 3, UserId = Convert.ToInt64(2) });
            modelBuilder.Entity<Test>().HasData(new Test { Id = 4, UserId = Convert.ToInt64(1) });

            modelBuilder.Entity<Disease>().HasData(new Disease { Id = 1, Name = "Грипп", PriorProbability = 0.0065, Info = "Грипп", Link = "https://www.krasotaimedicina.ru/diseases/infectious/flu" });
            modelBuilder.Entity<Disease>().HasData(new Disease { Id = 2, Name = "Корь", PriorProbability = 0.0000031, Info = "Корь", Link = "https://www.krasotaimedicina.ru/diseases/infectious/measles" });
            modelBuilder.Entity<Disease>().HasData(new Disease { Id = 3, Name = "Краснуха", PriorProbability = 0.000037, Info = "Краснуха", Link = "https://www.krasotaimedicina.ru/diseases/infectious/rubella" });
            modelBuilder.Entity<Disease>().HasData(new Disease { Id = 4, Name = "Острый Бронхит", PriorProbability = 0.00857, Info = "Острый Бронхит", Link = "https://www.krasotaimedicina.ru/diseases/zabolevanija_pulmonology/acute-bronchitis" });
            modelBuilder.Entity<Disease>().HasData(new Disease { Id = 5, Name = "Кандиоз легких", PriorProbability = 0.00001022, Info = "Кандидоз легких", Link = "https://www.krasotaimedicina.ru/diseases/zabolevanija_pulmonology/pulmonary-candidiasis" });
            modelBuilder.Entity<Disease>().HasData(new Disease { Id = 6, Name = "Сыпной Тиф", PriorProbability = 0.00000142, Info = "Сыпной Тиф", Link = "https://www.krasotaimedicina.ru/diseases/infectious/typhus" });
            modelBuilder.Entity<Disease>().HasData(new Disease { Id = 7, Name = "Коронавирус", PriorProbability = 0.000532, Info = "Коронавирус", Link = "https://www.krasotaimedicina.ru/diseases/infectious/coronavirus" });

            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 1, Caption = "У Вас высокая температура" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 2, Caption = "Вы испытываете постоянный сухой кашель" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 3, Caption = "Наблюдаете насморк" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 4, Caption = "Проявляются красные пятна на коже и слизистых" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 5, Caption = "Испытываете боли в мышцах или суставах" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 6, Caption = "Усиливаются признаки кашля по ночам" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 7, Caption = "Наблюдается покраснение глаз" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 8, Caption = "Чувство слабости" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 9, Caption = "Кровоизлеяние в склерах" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 10, Caption = "Покраснение лица" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 11, Caption = "Сердцебиение более 60 ударов в минуту" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 12, Caption = "Испытываете тошноту" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 13, Caption = "Чувствуется боль в горле" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 14, Caption = "Головная ноющая боль" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 15, Caption = "Заметна ли бледность кожи" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 16, Caption = "Вы с трудом переносите яркий свет" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 17, Caption = "Заметно присутствие повышенного потоотделения кожи" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 18, Caption = "Присутствие сыпи по всему телу" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 19, Caption = "На мягком нёбе присутствуют красные пятна" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 20, Caption = "Кашель с выделением мокроты" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 21, Caption = "Затруднение дыхания" });
            modelBuilder.Entity<Symptom>().HasData(new Symptom { Id = 22, Caption = "Кашель с кровью" });

            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 1, DiseaseId = 1, SymptomId = 1, ExodusIsTrue = 0.8, ExodusIsFalse = 0.011});
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 2, DiseaseId = 1, SymptomId = 2, ExodusIsTrue = 0.75, ExodusIsFalse = 0.03 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 3, DiseaseId = 1, SymptomId = 3, ExodusIsTrue = 0.7, ExodusIsFalse = 0.13 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 4, DiseaseId = 1, SymptomId = 5, ExodusIsTrue = 0.45, ExodusIsFalse = 0.25 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 5, DiseaseId = 1, SymptomId = 8, ExodusIsTrue = 0.8, ExodusIsFalse = 0.12 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 6, DiseaseId = 1, SymptomId = 12, ExodusIsTrue = 0.45, ExodusIsFalse = 0.15 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 7, DiseaseId = 1, SymptomId = 15, ExodusIsTrue = 0.8, ExodusIsFalse = 0.001 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 8, DiseaseId = 1, SymptomId = 16, ExodusIsTrue = 0.5, ExodusIsFalse = 0.11 });

            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 9, DiseaseId = 2, SymptomId = 1, ExodusIsTrue = 0.85, ExodusIsFalse = 0.05 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 10, DiseaseId = 2, SymptomId = 2, ExodusIsTrue = 0.7, ExodusIsFalse = 0.015 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 11, DiseaseId = 2, SymptomId = 3, ExodusIsTrue = 0.8, ExodusIsFalse = 0.1 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 12, DiseaseId = 2, SymptomId = 8, ExodusIsTrue = 0.9, ExodusIsFalse = 0.01 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 13, DiseaseId = 2, SymptomId = 17, ExodusIsTrue = 0.9, ExodusIsFalse = 0.03 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 14, DiseaseId = 2, SymptomId = 18, ExodusIsTrue = 0.95, ExodusIsFalse = 0.1 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 15, DiseaseId = 2, SymptomId = 19, ExodusIsTrue = 0.5, ExodusIsFalse = 0.2 });

            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 16, DiseaseId = 3, SymptomId = 1, ExodusIsTrue = 0.9, ExodusIsFalse = 0.07 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 17, DiseaseId = 3, SymptomId = 3, ExodusIsTrue = 0.7, ExodusIsFalse = 0.06 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 18, DiseaseId = 3, SymptomId = 4, ExodusIsTrue = 0.9, ExodusIsFalse = 0.01 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 19, DiseaseId = 3, SymptomId = 6, ExodusIsTrue = 0.6, ExodusIsFalse = 0.13 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 20, DiseaseId = 3, SymptomId = 7, ExodusIsTrue = 0.1, ExodusIsFalse = 0.05 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 21, DiseaseId = 3, SymptomId = 18, ExodusIsTrue = 0.9, ExodusIsFalse = 0.03 });

            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 22, DiseaseId = 4, SymptomId = 8, ExodusIsTrue = 0.7, ExodusIsFalse = 0.05 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 23, DiseaseId = 4, SymptomId = 17, ExodusIsTrue = 0.05, ExodusIsFalse = 0.01 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 24, DiseaseId = 4, SymptomId = 20, ExodusIsTrue = 0.8, ExodusIsFalse = 0.02 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 25, DiseaseId = 4, SymptomId = 21, ExodusIsTrue = 0.9, ExodusIsFalse = 0.01 });

            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 26, DiseaseId = 5, SymptomId = 1, ExodusIsTrue = 0.8, ExodusIsFalse = 0.01 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 27, DiseaseId = 5, SymptomId = 20, ExodusIsTrue = 0.85, ExodusIsFalse = 0.01 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 28, DiseaseId = 5, SymptomId = 22, ExodusIsTrue = 0.3, ExodusIsFalse = 0.01 });

            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 29, DiseaseId = 6, SymptomId = 1, ExodusIsTrue = 0.9, ExodusIsFalse = 0.03 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 30, DiseaseId = 6, SymptomId = 8, ExodusIsTrue = 0.87, ExodusIsFalse = 0.15 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 31, DiseaseId = 6, SymptomId = 9, ExodusIsTrue = 0.92, ExodusIsFalse = 0.01 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 32, DiseaseId = 6, SymptomId = 10, ExodusIsTrue = 0.9, ExodusIsFalse = 0.04 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 33, DiseaseId = 6, SymptomId = 11, ExodusIsTrue = 0.5, ExodusIsFalse = 0.05 });

            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 34, DiseaseId = 7, SymptomId = 1, ExodusIsTrue = 0.4, ExodusIsFalse = 0.03 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 35, DiseaseId = 7, SymptomId = 2, ExodusIsTrue = 0.7, ExodusIsFalse = 0.05 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 36, DiseaseId = 7, SymptomId = 3, ExodusIsTrue = 0.22, ExodusIsFalse = 0.04 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 37, DiseaseId = 7, SymptomId = 8, ExodusIsTrue = 0.6, ExodusIsFalse = 0.1 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 38, DiseaseId = 7, SymptomId = 12, ExodusIsTrue = 0.25, ExodusIsFalse = 0.03 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 39, DiseaseId = 7, SymptomId = 13, ExodusIsTrue = 0.2, ExodusIsFalse = 0.1 });
            modelBuilder.Entity<Coefficient>().HasData(new Coefficient { Id = 40, DiseaseId = 7, SymptomId = 21, ExodusIsTrue = 0.15, ExodusIsFalse = 0.03 });
        }
    }
}
