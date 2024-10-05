using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectEF.Migrations
{
    /// <inheritdoc />
    public partial class InitialDataConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("142b9ff2-d4d9-4e07-aca5-5447e2c6671b"), "Tareas personales", "Personal", 1 },
                    { new Guid("761a7528-5523-4bc8-9695-bd46e46441b5"), "Tareas de trabajo", "Work", 2 },
                    { new Guid("cb77479f-3fcb-4097-beed-4c3f30b30974"), "Tareas de estudio", "Study", 3 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "DateCreation", "Description", "PriorityTask", "Title" },
                values: new object[,]
                {
                    { new Guid("1f6ddff5-c06b-46ac-bd1b-7838d0842943"), new Guid("142b9ff2-d4d9-4e07-aca5-5447e2c6671b"), new DateTime(2024, 10, 4, 17, 56, 0, 416, DateTimeKind.Local).AddTicks(6690), "Descripcion de tarea 1", "High", "Tarea 1" },
                    { new Guid("8421b4f1-a1e5-49da-9af2-98fe19b82a22"), new Guid("761a7528-5523-4bc8-9695-bd46e46441b5"), new DateTime(2024, 10, 4, 17, 56, 0, 425, DateTimeKind.Local).AddTicks(2542), "Descripcion de tarea 2", "Medium", "Tarea 2" },
                    { new Guid("e0b655a4-270f-412e-8c62-f3f3b64fc161"), new Guid("cb77479f-3fcb-4097-beed-4c3f30b30974"), new DateTime(2024, 10, 4, 17, 56, 0, 425, DateTimeKind.Local).AddTicks(2594), "Descripcion de tarea 3", "Low", "Tarea 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("1f6ddff5-c06b-46ac-bd1b-7838d0842943"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("8421b4f1-a1e5-49da-9af2-98fe19b82a22"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("e0b655a4-270f-412e-8c62-f3f3b64fc161"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("142b9ff2-d4d9-4e07-aca5-5447e2c6671b"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("761a7528-5523-4bc8-9695-bd46e46441b5"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("cb77479f-3fcb-4097-beed-4c3f30b30974"));

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
    }
}
