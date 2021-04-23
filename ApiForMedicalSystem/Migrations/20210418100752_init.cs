using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiForMedicalSystem.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnswerUserItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<bool>(type: "bit", nullable: false),
                    TestId = table.Column<long>(type: "bigint", nullable: false),
                    SymptomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerUserItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoefficientItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseId = table.Column<int>(type: "int", nullable: false),
                    SymptomId = table.Column<int>(type: "int", nullable: false),
                    ExodusIsTrue = table.Column<double>(type: "float", nullable: false),
                    ExodusIsFalse = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoefficientItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriorProbability = table.Column<double>(type: "float", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResultItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseId = table.Column<int>(type: "int", nullable: false),
                    AnswerUserId = table.Column<int>(type: "int", nullable: false),
                    PriorProbability = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SymptomItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymptomItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BMI = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserItem", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CoefficientItem",
                columns: new[] { "Id", "DiseaseId", "ExodusIsFalse", "ExodusIsTrue", "SymptomId" },
                values: new object[,]
                {
                    { 1, 1, 0.010999999999999999, 0.80000000000000004, 1 },
                    { 23, 4, 0.01, 0.050000000000000003, 17 },
                    { 24, 4, 0.02, 0.80000000000000004, 20 },
                    { 25, 4, 0.01, 0.90000000000000002, 21 },
                    { 26, 5, 0.01, 0.80000000000000004, 1 },
                    { 27, 5, 0.01, 0.84999999999999998, 20 },
                    { 28, 5, 0.01, 0.29999999999999999, 22 },
                    { 29, 6, 0.029999999999999999, 0.90000000000000002, 1 },
                    { 30, 6, 0.14999999999999999, 0.87, 8 },
                    { 31, 6, 0.01, 0.92000000000000004, 9 },
                    { 32, 6, 0.040000000000000001, 0.90000000000000002, 10 },
                    { 33, 6, 0.050000000000000003, 0.5, 11 },
                    { 34, 7, 0.029999999999999999, 0.40000000000000002, 1 },
                    { 35, 7, 0.050000000000000003, 0.69999999999999996, 2 },
                    { 36, 7, 0.040000000000000001, 0.22, 3 },
                    { 37, 7, 0.10000000000000001, 0.59999999999999998, 8 },
                    { 39, 7, 0.10000000000000001, 0.20000000000000001, 13 },
                    { 40, 7, 0.029999999999999999, 0.14999999999999999, 21 },
                    { 22, 4, 0.050000000000000003, 0.69999999999999996, 8 },
                    { 21, 3, 0.029999999999999999, 0.90000000000000002, 18 },
                    { 38, 7, 0.029999999999999999, 0.25, 12 },
                    { 19, 3, 0.13, 0.59999999999999998, 6 },
                    { 20, 3, 0.050000000000000003, 0.10000000000000001, 7 },
                    { 3, 1, 0.13, 0.69999999999999996, 3 },
                    { 4, 1, 0.25, 0.45000000000000001, 5 },
                    { 5, 1, 0.12, 0.80000000000000004, 8 },
                    { 6, 1, 0.14999999999999999, 0.45000000000000001, 12 },
                    { 7, 1, 0.001, 0.80000000000000004, 15 },
                    { 8, 1, 0.11, 0.5, 16 },
                    { 9, 2, 0.050000000000000003, 0.84999999999999998, 1 },
                    { 2, 1, 0.029999999999999999, 0.75, 2 },
                    { 11, 2, 0.10000000000000001, 0.80000000000000004, 3 },
                    { 12, 2, 0.01, 0.90000000000000002, 8 },
                    { 13, 2, 0.029999999999999999, 0.90000000000000002, 17 },
                    { 14, 2, 0.10000000000000001, 0.94999999999999996, 18 },
                    { 15, 2, 0.20000000000000001, 0.5, 19 },
                    { 16, 3, 0.070000000000000007, 0.90000000000000002, 1 },
                    { 18, 3, 0.01, 0.90000000000000002, 4 },
                    { 17, 3, 0.059999999999999998, 0.69999999999999996, 3 },
                    { 10, 2, 0.014999999999999999, 0.69999999999999996, 2 }
                });

            migrationBuilder.InsertData(
                table: "DiseaseItem",
                columns: new[] { "Id", "Info", "Link", "Name", "PriorProbability" },
                values: new object[,]
                {
                    { 7, "Коронавирус", "https://www.krasotaimedicina.ru/diseases/infectious/coronavirus", "Коронавирус", 0.00053200000000000003 },
                    { 6, "Сыпной Тиф", "https://www.krasotaimedicina.ru/diseases/infectious/typhus", "Сыпной Тиф", 1.42E-06 }
                });

            migrationBuilder.InsertData(
                table: "DiseaseItem",
                columns: new[] { "Id", "Info", "Link", "Name", "PriorProbability" },
                values: new object[,]
                {
                    { 4, "Острый Бронхит", "https://www.krasotaimedicina.ru/diseases/zabolevanija_pulmonology/acute-bronchitis", "Острый Бронхит", 0.0085699999999999995 },
                    { 5, "Кандидоз легких", "https://www.krasotaimedicina.ru/diseases/zabolevanija_pulmonology/pulmonary-candidiasis", "Кандиоз легких", 1.022E-05 },
                    { 2, "Корь", "https://www.krasotaimedicina.ru/diseases/infectious/measles", "Корь", 3.1E-06 },
                    { 1, "Грипп", "https://www.krasotaimedicina.ru/diseases/infectious/flu", "Грипп", 0.0064999999999999997 },
                    { 3, "Краснуха", "https://www.krasotaimedicina.ru/diseases/infectious/rubella", "Краснуха", 3.6999999999999998E-05 }
                });

            migrationBuilder.InsertData(
                table: "SymptomItem",
                columns: new[] { "Id", "Caption" },
                values: new object[,]
                {
                    { 13, "Чувствуется боль в горле" },
                    { 22, "Кашель с кровью" },
                    { 21, "Затруднение дыхания" },
                    { 20, "Кашель с выделением мокроты" },
                    { 19, "На мягком нёбе присутствуют красные пятна" },
                    { 18, "Присутствие сыпи по всему телу" },
                    { 17, "Заметно присутствие повышенного потоотделения кожи" },
                    { 16, "Вы с трудом переносите яркий свет" },
                    { 15, "Заметна ли бледность кожи" },
                    { 14, "Головная ноющая боль" },
                    { 12, "Испытываете тошноту" },
                    { 1, "У Вас высокая температура" },
                    { 10, "Покраснение лица" },
                    { 9, "Кровоизлеяние в склерах" },
                    { 8, "Чувство слабости" },
                    { 7, "Наблюдается покраснение глаз" },
                    { 6, "Усиливаются признаки кашля по ночам" },
                    { 5, "Испытываете боли в мышцах или суставах" },
                    { 4, "Проявляются красные пятна на коже и слизистых" },
                    { 3, "Наблюдаете насморк" },
                    { 2, "Вы испытываете постоянный сухой кашель" },
                    { 11, "Сердцебиение более 60 ударов в минуту" }
                });

            migrationBuilder.InsertData(
                table: "TestItem",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, 1L },
                    { 2, 1L },
                    { 3, 2L },
                    { 4, 1L }
                });

            migrationBuilder.InsertData(
                table: "UserItem",
                columns: new[] { "Id", "Age", "BMI", "Gender", "Height", "Login", "Password", "Weight" },
                values: new object[,]
                {
                    { 1L, 22, 80.0, "female", 170.0, "user1", "user1", 70.0 },
                    { 2L, 30, 100.0, "male", 180.0, "user2", "user2", 90.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnswerUserItem");

            migrationBuilder.DropTable(
                name: "CoefficientItem");

            migrationBuilder.DropTable(
                name: "DiseaseItem");

            migrationBuilder.DropTable(
                name: "ResultItem");

            migrationBuilder.DropTable(
                name: "SymptomItem");

            migrationBuilder.DropTable(
                name: "TestItem");

            migrationBuilder.DropTable(
                name: "UserItem");
        }
    }
}
