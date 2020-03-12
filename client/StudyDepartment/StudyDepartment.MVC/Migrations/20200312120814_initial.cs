using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyDepartment.Domain.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExamTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Surname = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SecondName = table.Column<string>(nullable: true),
                    StudyGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_StudyGroups_StudyGroupId",
                        column: x => x.StudyGroupId,
                        principalTable: "StudyGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SubjectId = table.Column<int>(nullable: false),
                    ExamTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyPlans_ExamTypes_ExamTypeId",
                        column: x => x.ExamTypeId,
                        principalTable: "ExamTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyPlans_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jurnals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentId = table.Column<int>(nullable: false),
                    StudyPlanId = table.Column<int>(nullable: false),
                    InTime = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    MarkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jurnals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jurnals_Marks_MarkId",
                        column: x => x.MarkId,
                        principalTable: "Marks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jurnals_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jurnals_StudyPlans_StudyPlanId",
                        column: x => x.StudyPlanId,
                        principalTable: "StudyPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExamTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Экзамен" });

            migrationBuilder.InsertData(
                table: "ExamTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 2, "Зачет" });

            migrationBuilder.InsertData(
                table: "ExamTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 3, "Зачет с оценкой" });

            migrationBuilder.InsertData(
                table: "ExamTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 4, "Курсовая" });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[] { 7, "НЕявка", "" });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[] { 6, "Незачет", "н" });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[] { 4, "Неудовлетворительно", "2" });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[] { 5, "Зачет", "з" });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[] { 2, "Хорошо", "4" });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[] { 1, "Отлично", "5" });

            migrationBuilder.InsertData(
                table: "Marks",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[] { 3, "Удовлетворительно", "3" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 6, "Распределенные базы данных", "РБД" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 1, "Проектирование информационных систем", "ПрИС" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 2, "Системы искусственного интеллекта", "СИИ" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 3, "Программная инженерия", "ПИ" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 4, "Национальная система информационной безопасности", "НСИБ" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 5, "Системный анализ", "СисАнал" });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[] { 7, "Системное программное обеспечение", "СПО" });

            migrationBuilder.InsertData(
                table: "StudyPlans",
                columns: new[] { "Id", "ExamTypeId", "SubjectId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "StudyPlans",
                columns: new[] { "Id", "ExamTypeId", "SubjectId" },
                values: new object[] { 2, 4, 1 });

            migrationBuilder.InsertData(
                table: "StudyPlans",
                columns: new[] { "Id", "ExamTypeId", "SubjectId" },
                values: new object[] { 3, 1, 2 });

            migrationBuilder.InsertData(
                table: "StudyPlans",
                columns: new[] { "Id", "ExamTypeId", "SubjectId" },
                values: new object[] { 4, 1, 3 });

            migrationBuilder.InsertData(
                table: "StudyPlans",
                columns: new[] { "Id", "ExamTypeId", "SubjectId" },
                values: new object[] { 5, 2, 4 });

            migrationBuilder.InsertData(
                table: "StudyPlans",
                columns: new[] { "Id", "ExamTypeId", "SubjectId" },
                values: new object[] { 6, 1, 5 });

            migrationBuilder.InsertData(
                table: "StudyPlans",
                columns: new[] { "Id", "ExamTypeId", "SubjectId" },
                values: new object[] { 7, 2, 6 });

            migrationBuilder.InsertData(
                table: "StudyPlans",
                columns: new[] { "Id", "ExamTypeId", "SubjectId" },
                values: new object[] { 8, 1, 7 });

            migrationBuilder.CreateIndex(
                name: "IX_Jurnals_MarkId",
                table: "Jurnals",
                column: "MarkId");

            migrationBuilder.CreateIndex(
                name: "IX_Jurnals_StudentId",
                table: "Jurnals",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Jurnals_StudyPlanId",
                table: "Jurnals",
                column: "StudyPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudyGroupId",
                table: "Students",
                column: "StudyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlans_ExamTypeId",
                table: "StudyPlans",
                column: "ExamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyPlans_SubjectId",
                table: "StudyPlans",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jurnals");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "StudyPlans");

            migrationBuilder.DropTable(
                name: "StudyGroups");

            migrationBuilder.DropTable(
                name: "ExamTypes");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
