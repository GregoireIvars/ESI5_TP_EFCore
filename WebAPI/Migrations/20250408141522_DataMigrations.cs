using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class DataMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Locations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Conférence" },
                    { 2, "Atelier" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "Capacity", "City", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "10 rue des Capucins, Lyon", 500, "Lyon", "France", "Campus Lyon" },
                    { 2, "5 avenue République, Paris", 300, "Paris", "France", "Campus Paris" }
                });

            migrationBuilder.InsertData(
                table: "Participants",
                columns: new[] { "Id", "Company", "Email", "FirstName", "JobTitle", "LastName" },
                values: new object[,]
                {
                    { 1, "TechCorp", "alice@example.com", "Alice", "Développeuse", "Martin" },
                    { 2, "InnoTech", "bob@example.com", "Bob", "Ingénieur", "Dupont" }
                });

            migrationBuilder.InsertData(
                table: "Speakers",
                columns: new[] { "Id", "Bio", "Company", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Expert en IA", "AI Solutions", "Jean.Du@gmail.com", "Jean", "Durand" },
                    { 2, "Spécialiste DevOps", "DevOps Inc.", "Marie38@outlook.fr", "Marie", "Leroy" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CategoryId", "EndDate", "LocationId", "StartDate", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upcoming", "Journée Tech 2025" },
                    { 2, 2, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upcoming", "Atelier DevOps" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, 100, 1, "Salle A" },
                    { 2, 50, 1, "Salle B" },
                    { 3, 75, 2, "Salle C" }
                });

            migrationBuilder.InsertData(
                table: "EventParticipants",
                columns: new[] { "EventId", "ParticipantId", "AttendanceDate", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Description", "EndDate", "EventId", "RoomId", "StartDate", "Title" },
                values: new object[,]
                {
                    { 1, "An introductory session on Artificial Intelligence.", new DateTime(2025, 6, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2025, 6, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "Introduction à l'IA" },
                    { 2, "A beginner's guide to Continuous Integration and Continuous Deployment.", new DateTime(2025, 4, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, new DateTime(2025, 4, 20, 14, 0, 0, 0, DateTimeKind.Unspecified), "CI/CD pour les nuls" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "Comments", "ParticipantId", "Score", "SessionId" },
                values: new object[,]
                {
                    { 1, "Great session!", 1, 4, 1 },
                    { 2, "Excellent workshop!", 1, 5, 2 },
                    { 3, "No comments provided.", 2, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "SessionSpeakers",
                columns: new[] { "SessionId", "SpeakerId", "AttendanceDate", "RegistrationDate", "Role" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keynote Speaker" },
                    { 2, 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Workshop Leader" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventParticipants",
                keyColumns: new[] { "EventId", "ParticipantId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "EventParticipants",
                keyColumns: new[] { "EventId", "ParticipantId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "EventParticipants",
                keyColumns: new[] { "EventId", "ParticipantId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ratings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SessionSpeakers",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "SessionSpeakers",
                keyColumns: new[] { "SessionId", "SpeakerId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Participants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Speakers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Capacity",
                table: "Locations",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
