using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwesomeLibrary.API.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "DateOfDeath", "FirstName", "LastName" },
                values: new object[,]
                {
                    { new Guid("2d02c1e4-9976-464e-a31c-4a3c8ff2b58b"), new DateTime(1943, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Peter", "Straub" },
                    { new Guid("82815d61-6858-43b3-9104-07a4182b8ef6"), new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Stephen", "King" },
                    { new Guid("b4a4a08f-7a45-4f5d-8b01-8df88ddcb84a"), new DateTime(1877, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1962, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hermann", "Hesse" },
                    { new Guid("f1751877-39ce-4c58-b8be-8e7969a9cc16"), new DateTime(1952, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Robert", "Martin" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Genre", "Pages", "Publisher", "PublishingYear", "Title" },
                values: new object[,]
                {
                    { new Guid("35b4208e-a3b7-404d-aa08-d2db7a386776"), "Horror", 498, "Hodder & Stoughton Ltd", 2007, "The Shining" },
                    { new Guid("498d1371-2cbe-4e36-8bd9-dcd041433d86"), "Spiritality", 216, "Rao", 2013, "Siddhartha" },
                    { new Guid("e973d751-c737-4f42-bcd7-80ed8304e826"), "Programming", 464, "Pearson Education", 2008, "Clean Code" },
                    { new Guid("fb7ac48e-6a30-426f-9ccc-e0a5659911e1"), "Fiction", 992, "Orion Publishing", 2012, "The Talisman" }
                });

            migrationBuilder.InsertData(
                table: "BooksAuthors",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { new Guid("2d02c1e4-9976-464e-a31c-4a3c8ff2b58b"), new Guid("fb7ac48e-6a30-426f-9ccc-e0a5659911e1") },
                    { new Guid("82815d61-6858-43b3-9104-07a4182b8ef6"), new Guid("35b4208e-a3b7-404d-aa08-d2db7a386776") },
                    { new Guid("82815d61-6858-43b3-9104-07a4182b8ef6"), new Guid("fb7ac48e-6a30-426f-9ccc-e0a5659911e1") },
                    { new Guid("b4a4a08f-7a45-4f5d-8b01-8df88ddcb84a"), new Guid("498d1371-2cbe-4e36-8bd9-dcd041433d86") },
                    { new Guid("f1751877-39ce-4c58-b8be-8e7969a9cc16"), new Guid("e973d751-c737-4f42-bcd7-80ed8304e826") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("2d02c1e4-9976-464e-a31c-4a3c8ff2b58b"), new Guid("fb7ac48e-6a30-426f-9ccc-e0a5659911e1") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("82815d61-6858-43b3-9104-07a4182b8ef6"), new Guid("35b4208e-a3b7-404d-aa08-d2db7a386776") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("82815d61-6858-43b3-9104-07a4182b8ef6"), new Guid("fb7ac48e-6a30-426f-9ccc-e0a5659911e1") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("b4a4a08f-7a45-4f5d-8b01-8df88ddcb84a"), new Guid("498d1371-2cbe-4e36-8bd9-dcd041433d86") });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { new Guid("f1751877-39ce-4c58-b8be-8e7969a9cc16"), new Guid("e973d751-c737-4f42-bcd7-80ed8304e826") });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("2d02c1e4-9976-464e-a31c-4a3c8ff2b58b"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("82815d61-6858-43b3-9104-07a4182b8ef6"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("b4a4a08f-7a45-4f5d-8b01-8df88ddcb84a"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("f1751877-39ce-4c58-b8be-8e7969a9cc16"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("35b4208e-a3b7-404d-aa08-d2db7a386776"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("498d1371-2cbe-4e36-8bd9-dcd041433d86"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e973d751-c737-4f42-bcd7-80ed8304e826"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("fb7ac48e-6a30-426f-9ccc-e0a5659911e1"));
        }
    }
}
