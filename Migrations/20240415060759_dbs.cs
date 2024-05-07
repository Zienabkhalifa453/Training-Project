using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCLab.Migrations
{
    /// <inheritdoc />
    public partial class dbs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    minDegree = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    departmentID = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainees_Departments_departmentID",
                        column: x => x.departmentID,
                        principalTable: "Departments",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    departmentID = table.Column<int>(type: "int", nullable: true),
                    courseID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Instructors_Courses_courseID",
                        column: x => x.courseID,
                        principalTable: "Courses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Instructors_Departments_departmentID",
                        column: x => x.departmentID,
                        principalTable: "Departments",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CrsResult",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<int>(type: "int", nullable: false),
                    TraineeID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrsResult", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CrsResult_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_CrsResult_Trainees_TraineeID",
                        column: x => x.TraineeID,
                        principalTable: "Trainees",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "ID", "ManagerName", "Name", "isDeleted" },
                values: new object[,]
                {
                    { 1, "Ayman", "SD", false },
                    { 2, "Sara", "HR", false },
                    { 3, "Ahmed", "Finance", false },
                    { 4, "Layla", "Marketing", false }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "Degree", "DepartmentID", "Hours", "IsDeleted", "Name", "minDegree" },
                values: new object[,]
                {
                    { 1, 90, 1, 40, false, "C#", 0 },
                    { 2, 85, 2, 35, false, "Java", 0 },
                    { 3, 88, 3, 45, false, "Python", 0 },
                    { 4, 92, 4, 30, false, "Marketing Strategies", 0 }
                });

            migrationBuilder.InsertData(
                table: "Trainees",
                columns: new[] { "Id", "Adress", "Grade", "Image", "Name", "departmentID", "isDeleted" },
                values: new object[,]
                {
                    { 1, "Alex", 95, "female.png", "Mariam", 1, false },
                    { 2, "Cairo", 85, "male.png", "Karim", 2, false },
                    { 3, "Giza", 75, "female.png", "Nour", 3, false },
                    { 4, "Luxor", 80, "male.png", "Tamer", 4, false }
                });

            migrationBuilder.InsertData(
                table: "CrsResult",
                columns: new[] { "ID", "CourseID", "Degree", "TraineeID" },
                values: new object[,]
                {
                    { 1, 1, 60, 1 },
                    { 2, 2, 75, 2 },
                    { 3, 3, 80, 3 },
                    { 4, 4, 85, 4 }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "ID", "Address", "Image", "Name", "Salary", "courseID", "departmentID", "isDeleted" },
                values: new object[,]
                {
                    { 1, "Address1", "m.png", "Ahmed", 0, 2, 1, false },
                    { 2, "Address2", "female.png", "Fatima", 0, 3, 2, false },
                    { 3, "Address3", "male.png", "Omar", 0, 4, 3, false },
                    { 4, "Address4", "2.jpg", "Lina", 0, 1, 4, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentID",
                table: "Courses",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_CrsResult_CourseID",
                table: "CrsResult",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CrsResult_TraineeID",
                table: "CrsResult",
                column: "TraineeID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_courseID",
                table: "Instructors",
                column: "courseID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_departmentID",
                table: "Instructors",
                column: "departmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_departmentID",
                table: "Trainees",
                column: "departmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrsResult");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
