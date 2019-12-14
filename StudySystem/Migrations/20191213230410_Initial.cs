using Microsoft.EntityFrameworkCore.Migrations;

namespace StudySystem.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "course",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_account",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_account", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "class",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    topic = table.Column<string>(maxLength: 255, nullable: false),
                    course_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_class", x => x.id);
                    table.ForeignKey(
                        name: "FK_class_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_account_to_course_link",
                columns: table => new
                {
                    user_account_id = table.Column<long>(nullable: false),
                    course_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_account_to_course_link", x => new { x.user_account_id, x.course_id });
                    table.ForeignKey(
                        name: "FK_user_account_to_course_link_course_course_id",
                        column: x => x.course_id,
                        principalTable: "course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_account_to_course_link_user_account_user_account_id",
                        column: x => x.user_account_id,
                        principalTable: "user_account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "individual_task",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    text = table.Column<string>(maxLength: 10000, nullable: false),
                    class_id = table.Column<long>(nullable: false),
                    student_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_individual_task", x => x.id);
                    table.ForeignKey(
                        name: "FK_individual_task_class_class_id",
                        column: x => x.class_id,
                        principalTable: "class",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_individual_task_class_student_id",
                        column: x => x.student_id,
                        principalTable: "class",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "task",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    text = table.Column<string>(maxLength: 10000, nullable: false),
                    class_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task", x => x.id);
                    table.ForeignKey(
                        name: "FK_task_class_class_id",
                        column: x => x.class_id,
                        principalTable: "class",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "individual_task_grade",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    grade = table.Column<int>(nullable: false),
                    task_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_individual_task_grade", x => x.id);
                    table.ForeignKey(
                        name: "FK_individual_task_grade_individual_task_task_id",
                        column: x => x.task_id,
                        principalTable: "individual_task",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "task_grade",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    grade = table.Column<int>(nullable: false),
                    task_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_task_grade", x => x.id);
                    table.ForeignKey(
                        name: "FK_task_grade_task_task_id",
                        column: x => x.task_id,
                        principalTable: "task",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_class_course_id",
                table: "class",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_individual_task_class_id",
                table: "individual_task",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_individual_task_student_id",
                table: "individual_task",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_individual_task_grade_task_id",
                table: "individual_task_grade",
                column: "task_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_task_class_id",
                table: "task",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_task_grade_task_id",
                table: "task_grade",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_user_account_to_course_link_course_id",
                table: "user_account_to_course_link",
                column: "course_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "individual_task_grade");

            migrationBuilder.DropTable(
                name: "task_grade");

            migrationBuilder.DropTable(
                name: "user_account_to_course_link");

            migrationBuilder.DropTable(
                name: "individual_task");

            migrationBuilder.DropTable(
                name: "task");

            migrationBuilder.DropTable(
                name: "user_account");

            migrationBuilder.DropTable(
                name: "class");

            migrationBuilder.DropTable(
                name: "course");
        }
    }
}
