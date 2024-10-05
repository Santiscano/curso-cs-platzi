using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("461c114b-f6d7-4ba5-a778-9bc976ac4d51"), "Tareas personales", "Personal", 1 },
                    { new Guid("98385b5e-d1e3-408f-88aa-b3a1bd105d7c"), "Tareas de estudio", "Study", 3 },
                    { new Guid("c6c73916-7a34-4208-9d6e-7c4a52c443f5"), "Tareas de trabajo", "Work", 2 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "DateCreation", "Description", "PriorityTask", "Title" },
                values: new object[,]
                {
                    { new Guid("32e5f6a5-1098-40a3-bc62-9e6d311c375a"), new Guid("461c114b-f6d7-4ba5-a778-9bc976ac4d51"), new DateTime(2024, 10, 4, 17, 44, 5, 974, DateTimeKind.Local).AddTicks(7730), "Descripcion de tarea 1", "High", "Tarea 1" },
                    { new Guid("9877aa69-74b2-41df-ad89-21dd3d1247f1"), new Guid("98385b5e-d1e3-408f-88aa-b3a1bd105d7c"), new DateTime(2024, 10, 4, 17, 44, 5, 984, DateTimeKind.Local).AddTicks(3102), "Descripcion de tarea 3", "Low", "Tarea 3" },
                    { new Guid("fbc35d9d-1cf7-4d1a-bb77-a99143816aa7"), new Guid("c6c73916-7a34-4208-9d6e-7c4a52c443f5"), new DateTime(2024, 10, 4, 17, 44, 5, 984, DateTimeKind.Local).AddTicks(2999), "Descripcion de tarea 2", "Medium", "Tarea 2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("32e5f6a5-1098-40a3-bc62-9e6d311c375a"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("9877aa69-74b2-41df-ad89-21dd3d1247f1"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("fbc35d9d-1cf7-4d1a-bb77-a99143816aa7"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("461c114b-f6d7-4ba5-a778-9bc976ac4d51"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("98385b5e-d1e3-408f-88aa-b3a1bd105d7c"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("c6c73916-7a34-4208-9d6e-7c4a52c443f5"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
