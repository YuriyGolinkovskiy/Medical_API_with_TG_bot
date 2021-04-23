﻿// <auto-generated />
using ApiForMedicalSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ApiForMedicalSystem.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApiForMedicalSystem.Models.AnswerUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Answer")
                        .HasColumnType("bit");

                    b.Property<int>("SymptomId")
                        .HasColumnType("int");

                    b.Property<long>("TestId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("AnswerUserItem");
                });

            modelBuilder.Entity("ApiForMedicalSystem.Models.Coefficient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<double>("ExodusIsFalse")
                        .HasColumnType("float");

                    b.Property<double>("ExodusIsTrue")
                        .HasColumnType("float");

                    b.Property<int>("SymptomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CoefficientItem");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DiseaseId = 1,
                            ExodusIsFalse = 0.010999999999999999,
                            ExodusIsTrue = 0.80000000000000004,
                            SymptomId = 1
                        },
                        new
                        {
                            Id = 2,
                            DiseaseId = 1,
                            ExodusIsFalse = 0.029999999999999999,
                            ExodusIsTrue = 0.75,
                            SymptomId = 2
                        },
                        new
                        {
                            Id = 3,
                            DiseaseId = 1,
                            ExodusIsFalse = 0.13,
                            ExodusIsTrue = 0.69999999999999996,
                            SymptomId = 3
                        },
                        new
                        {
                            Id = 4,
                            DiseaseId = 1,
                            ExodusIsFalse = 0.25,
                            ExodusIsTrue = 0.45000000000000001,
                            SymptomId = 5
                        },
                        new
                        {
                            Id = 5,
                            DiseaseId = 1,
                            ExodusIsFalse = 0.12,
                            ExodusIsTrue = 0.80000000000000004,
                            SymptomId = 8
                        },
                        new
                        {
                            Id = 6,
                            DiseaseId = 1,
                            ExodusIsFalse = 0.14999999999999999,
                            ExodusIsTrue = 0.45000000000000001,
                            SymptomId = 12
                        },
                        new
                        {
                            Id = 7,
                            DiseaseId = 1,
                            ExodusIsFalse = 0.001,
                            ExodusIsTrue = 0.80000000000000004,
                            SymptomId = 15
                        },
                        new
                        {
                            Id = 8,
                            DiseaseId = 1,
                            ExodusIsFalse = 0.11,
                            ExodusIsTrue = 0.5,
                            SymptomId = 16
                        },
                        new
                        {
                            Id = 9,
                            DiseaseId = 2,
                            ExodusIsFalse = 0.050000000000000003,
                            ExodusIsTrue = 0.84999999999999998,
                            SymptomId = 1
                        },
                        new
                        {
                            Id = 10,
                            DiseaseId = 2,
                            ExodusIsFalse = 0.014999999999999999,
                            ExodusIsTrue = 0.69999999999999996,
                            SymptomId = 2
                        },
                        new
                        {
                            Id = 11,
                            DiseaseId = 2,
                            ExodusIsFalse = 0.10000000000000001,
                            ExodusIsTrue = 0.80000000000000004,
                            SymptomId = 3
                        },
                        new
                        {
                            Id = 12,
                            DiseaseId = 2,
                            ExodusIsFalse = 0.01,
                            ExodusIsTrue = 0.90000000000000002,
                            SymptomId = 8
                        },
                        new
                        {
                            Id = 13,
                            DiseaseId = 2,
                            ExodusIsFalse = 0.029999999999999999,
                            ExodusIsTrue = 0.90000000000000002,
                            SymptomId = 17
                        },
                        new
                        {
                            Id = 14,
                            DiseaseId = 2,
                            ExodusIsFalse = 0.10000000000000001,
                            ExodusIsTrue = 0.94999999999999996,
                            SymptomId = 18
                        },
                        new
                        {
                            Id = 15,
                            DiseaseId = 2,
                            ExodusIsFalse = 0.20000000000000001,
                            ExodusIsTrue = 0.5,
                            SymptomId = 19
                        },
                        new
                        {
                            Id = 16,
                            DiseaseId = 3,
                            ExodusIsFalse = 0.070000000000000007,
                            ExodusIsTrue = 0.90000000000000002,
                            SymptomId = 1
                        },
                        new
                        {
                            Id = 17,
                            DiseaseId = 3,
                            ExodusIsFalse = 0.059999999999999998,
                            ExodusIsTrue = 0.69999999999999996,
                            SymptomId = 3
                        },
                        new
                        {
                            Id = 18,
                            DiseaseId = 3,
                            ExodusIsFalse = 0.01,
                            ExodusIsTrue = 0.90000000000000002,
                            SymptomId = 4
                        },
                        new
                        {
                            Id = 19,
                            DiseaseId = 3,
                            ExodusIsFalse = 0.13,
                            ExodusIsTrue = 0.59999999999999998,
                            SymptomId = 6
                        },
                        new
                        {
                            Id = 20,
                            DiseaseId = 3,
                            ExodusIsFalse = 0.050000000000000003,
                            ExodusIsTrue = 0.10000000000000001,
                            SymptomId = 7
                        },
                        new
                        {
                            Id = 21,
                            DiseaseId = 3,
                            ExodusIsFalse = 0.029999999999999999,
                            ExodusIsTrue = 0.90000000000000002,
                            SymptomId = 18
                        },
                        new
                        {
                            Id = 22,
                            DiseaseId = 4,
                            ExodusIsFalse = 0.050000000000000003,
                            ExodusIsTrue = 0.69999999999999996,
                            SymptomId = 8
                        },
                        new
                        {
                            Id = 23,
                            DiseaseId = 4,
                            ExodusIsFalse = 0.01,
                            ExodusIsTrue = 0.050000000000000003,
                            SymptomId = 17
                        },
                        new
                        {
                            Id = 24,
                            DiseaseId = 4,
                            ExodusIsFalse = 0.02,
                            ExodusIsTrue = 0.80000000000000004,
                            SymptomId = 20
                        },
                        new
                        {
                            Id = 25,
                            DiseaseId = 4,
                            ExodusIsFalse = 0.01,
                            ExodusIsTrue = 0.90000000000000002,
                            SymptomId = 21
                        },
                        new
                        {
                            Id = 26,
                            DiseaseId = 5,
                            ExodusIsFalse = 0.01,
                            ExodusIsTrue = 0.80000000000000004,
                            SymptomId = 1
                        },
                        new
                        {
                            Id = 27,
                            DiseaseId = 5,
                            ExodusIsFalse = 0.01,
                            ExodusIsTrue = 0.84999999999999998,
                            SymptomId = 20
                        },
                        new
                        {
                            Id = 28,
                            DiseaseId = 5,
                            ExodusIsFalse = 0.01,
                            ExodusIsTrue = 0.29999999999999999,
                            SymptomId = 22
                        },
                        new
                        {
                            Id = 29,
                            DiseaseId = 6,
                            ExodusIsFalse = 0.029999999999999999,
                            ExodusIsTrue = 0.90000000000000002,
                            SymptomId = 1
                        },
                        new
                        {
                            Id = 30,
                            DiseaseId = 6,
                            ExodusIsFalse = 0.14999999999999999,
                            ExodusIsTrue = 0.87,
                            SymptomId = 8
                        },
                        new
                        {
                            Id = 31,
                            DiseaseId = 6,
                            ExodusIsFalse = 0.01,
                            ExodusIsTrue = 0.92000000000000004,
                            SymptomId = 9
                        },
                        new
                        {
                            Id = 32,
                            DiseaseId = 6,
                            ExodusIsFalse = 0.040000000000000001,
                            ExodusIsTrue = 0.90000000000000002,
                            SymptomId = 10
                        },
                        new
                        {
                            Id = 33,
                            DiseaseId = 6,
                            ExodusIsFalse = 0.050000000000000003,
                            ExodusIsTrue = 0.5,
                            SymptomId = 11
                        },
                        new
                        {
                            Id = 34,
                            DiseaseId = 7,
                            ExodusIsFalse = 0.029999999999999999,
                            ExodusIsTrue = 0.40000000000000002,
                            SymptomId = 1
                        },
                        new
                        {
                            Id = 35,
                            DiseaseId = 7,
                            ExodusIsFalse = 0.050000000000000003,
                            ExodusIsTrue = 0.69999999999999996,
                            SymptomId = 2
                        },
                        new
                        {
                            Id = 36,
                            DiseaseId = 7,
                            ExodusIsFalse = 0.040000000000000001,
                            ExodusIsTrue = 0.22,
                            SymptomId = 3
                        },
                        new
                        {
                            Id = 37,
                            DiseaseId = 7,
                            ExodusIsFalse = 0.10000000000000001,
                            ExodusIsTrue = 0.59999999999999998,
                            SymptomId = 8
                        },
                        new
                        {
                            Id = 38,
                            DiseaseId = 7,
                            ExodusIsFalse = 0.029999999999999999,
                            ExodusIsTrue = 0.25,
                            SymptomId = 12
                        },
                        new
                        {
                            Id = 39,
                            DiseaseId = 7,
                            ExodusIsFalse = 0.10000000000000001,
                            ExodusIsTrue = 0.20000000000000001,
                            SymptomId = 13
                        },
                        new
                        {
                            Id = 40,
                            DiseaseId = 7,
                            ExodusIsFalse = 0.029999999999999999,
                            ExodusIsTrue = 0.14999999999999999,
                            SymptomId = 21
                        });
                });

            modelBuilder.Entity("ApiForMedicalSystem.Models.Disease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PriorProbability")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("DiseaseItem");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Info = "Грипп",
                            Link = "https://www.krasotaimedicina.ru/diseases/infectious/flu",
                            Name = "Грипп",
                            PriorProbability = 0.0064999999999999997
                        },
                        new
                        {
                            Id = 2,
                            Info = "Корь",
                            Link = "https://www.krasotaimedicina.ru/diseases/infectious/measles",
                            Name = "Корь",
                            PriorProbability = 3.1E-06
                        },
                        new
                        {
                            Id = 3,
                            Info = "Краснуха",
                            Link = "https://www.krasotaimedicina.ru/diseases/infectious/rubella",
                            Name = "Краснуха",
                            PriorProbability = 3.6999999999999998E-05
                        },
                        new
                        {
                            Id = 4,
                            Info = "Острый Бронхит",
                            Link = "https://www.krasotaimedicina.ru/diseases/zabolevanija_pulmonology/acute-bronchitis",
                            Name = "Острый Бронхит",
                            PriorProbability = 0.0085699999999999995
                        },
                        new
                        {
                            Id = 5,
                            Info = "Кандидоз легких",
                            Link = "https://www.krasotaimedicina.ru/diseases/zabolevanija_pulmonology/pulmonary-candidiasis",
                            Name = "Кандиоз легких",
                            PriorProbability = 1.022E-05
                        },
                        new
                        {
                            Id = 6,
                            Info = "Сыпной Тиф",
                            Link = "https://www.krasotaimedicina.ru/diseases/infectious/typhus",
                            Name = "Сыпной Тиф",
                            PriorProbability = 1.42E-06
                        },
                        new
                        {
                            Id = 7,
                            Info = "Коронавирус",
                            Link = "https://www.krasotaimedicina.ru/diseases/infectious/coronavirus",
                            Name = "Коронавирус",
                            PriorProbability = 0.00053200000000000003
                        });
                });

            modelBuilder.Entity("ApiForMedicalSystem.Models.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnswerUserId")
                        .HasColumnType("int");

                    b.Property<int>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<double>("PriorProbability")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ResultItem");
                });

            modelBuilder.Entity("ApiForMedicalSystem.Models.Symptom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SymptomItem");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Caption = "У Вас высокая температура"
                        },
                        new
                        {
                            Id = 2,
                            Caption = "Вы испытываете постоянный сухой кашель"
                        },
                        new
                        {
                            Id = 3,
                            Caption = "Наблюдаете насморк"
                        },
                        new
                        {
                            Id = 4,
                            Caption = "Проявляются красные пятна на коже и слизистых"
                        },
                        new
                        {
                            Id = 5,
                            Caption = "Испытываете боли в мышцах или суставах"
                        },
                        new
                        {
                            Id = 6,
                            Caption = "Усиливаются признаки кашля по ночам"
                        },
                        new
                        {
                            Id = 7,
                            Caption = "Наблюдается покраснение глаз"
                        },
                        new
                        {
                            Id = 8,
                            Caption = "Чувство слабости"
                        },
                        new
                        {
                            Id = 9,
                            Caption = "Кровоизлеяние в склерах"
                        },
                        new
                        {
                            Id = 10,
                            Caption = "Покраснение лица"
                        },
                        new
                        {
                            Id = 11,
                            Caption = "Сердцебиение более 60 ударов в минуту"
                        },
                        new
                        {
                            Id = 12,
                            Caption = "Испытываете тошноту"
                        },
                        new
                        {
                            Id = 13,
                            Caption = "Чувствуется боль в горле"
                        },
                        new
                        {
                            Id = 14,
                            Caption = "Головная ноющая боль"
                        },
                        new
                        {
                            Id = 15,
                            Caption = "Заметна ли бледность кожи"
                        },
                        new
                        {
                            Id = 16,
                            Caption = "Вы с трудом переносите яркий свет"
                        },
                        new
                        {
                            Id = 17,
                            Caption = "Заметно присутствие повышенного потоотделения кожи"
                        },
                        new
                        {
                            Id = 18,
                            Caption = "Присутствие сыпи по всему телу"
                        },
                        new
                        {
                            Id = 19,
                            Caption = "На мягком нёбе присутствуют красные пятна"
                        },
                        new
                        {
                            Id = 20,
                            Caption = "Кашель с выделением мокроты"
                        },
                        new
                        {
                            Id = 21,
                            Caption = "Затруднение дыхания"
                        },
                        new
                        {
                            Id = 22,
                            Caption = "Кашель с кровью"
                        });
                });

            modelBuilder.Entity("ApiForMedicalSystem.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("TestItem");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserId = 1L
                        },
                        new
                        {
                            Id = 2,
                            UserId = 1L
                        },
                        new
                        {
                            Id = 3,
                            UserId = 2L
                        },
                        new
                        {
                            Id = 4,
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("ApiForMedicalSystem.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<double>("BMI")
                        .HasColumnType("float");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Height")
                        .HasColumnType("float");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("UserItem");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Age = 22,
                            BMI = 80.0,
                            Gender = "female",
                            Height = 170.0,
                            Login = "user1",
                            Password = "user1",
                            Weight = 70.0
                        },
                        new
                        {
                            Id = 2L,
                            Age = 30,
                            BMI = 100.0,
                            Gender = "male",
                            Height = 180.0,
                            Login = "user2",
                            Password = "user2",
                            Weight = 90.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
