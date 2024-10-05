using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace projectEF.Migrations
{
    /// <inheritdoc />
    public partial class WithoutWieght : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Category");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("01fe5696-becf-48a4-9635-bc1d50fc7780"), "Tareas personales", "Personal" },
                    { new Guid("50440794-3e32-40e7-91f5-0f41d985554c"), "Tareas de trabajo", "Work" },
                    { new Guid("67c39bd6-8131-4b31-9b3e-af5446c9b9e4"), "Tareas de estudio", "Study" }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "DateCreation", "Description", "PriorityTask", "Title" },
                values: new object[,]
                {
                    { new Guid("4d86bde1-2e26-40d8-afa7-ad63a324e4f4"), new Guid("50440794-3e32-40e7-91f5-0f41d985554c"), new DateTime(2024, 10, 4, 19, 41, 3, 874, DateTimeKind.Local).AddTicks(4524), "Descripcion de tarea 2", "Medium", "Tarea 2" },
                    { new Guid("7ae3ceee-2696-4a7c-bea2-979d29aeddd1"), new Guid("67c39bd6-8131-4b31-9b3e-af5446c9b9e4"), new DateTime(2024, 10, 4, 19, 41, 3, 874, DateTimeKind.Local).AddTicks(4553), "Descripcion de tarea 3", "Low", "Tarea 3" },
                    { new Guid("ea578989-c5ba-4cdf-9406-44299158395d"), new Guid("01fe5696-becf-48a4-9635-bc1d50fc7780"), new DateTime(2024, 10, 4, 19, 41, 3, 870, DateTimeKind.Local).AddTicks(2401), "Descripcion de tarea 1", "High", "Tarea 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("4d86bde1-2e26-40d8-afa7-ad63a324e4f4"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("7ae3ceee-2696-4a7c-bea2-979d29aeddd1"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("ea578989-c5ba-4cdf-9406-44299158395d"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("01fe5696-becf-48a4-9635-bc1d50fc7780"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("50440794-3e32-40e7-91f5-0f41d985554c"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("67c39bd6-8131-4b31-9b3e-af5446c9b9e4"));

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
