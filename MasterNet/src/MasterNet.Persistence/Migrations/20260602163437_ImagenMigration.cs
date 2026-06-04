using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MasterNet.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ImagenMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12eb52e1-b752-4201-ba7a-cd0c9d11741a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56c09327-b80d-4ef2-8f2d-b5a9c5f508a2");

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("3e28b445-70ef-4883-976a-2d8877a17135"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("6003c89c-9950-4ad3-8ede-586b578e37ce"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("61ade3ef-d6ba-4973-95bd-d8508dd9da6f"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("a050a136-a093-45e7-b868-ccef76367016"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("a6d2f52f-c918-4a99-9c83-dfe504bf9f92"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("b2e838a8-6678-4ac0-9382-4826c11634eb"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("c5105bc7-3794-4425-bca5-fef25886600b"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("ede29c81-a20e-4f68-abcc-7edcfe440073"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("f1960fc1-5be7-40f2-b1c3-a48c2cd18930"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("0deceb3a-44e0-4953-a026-abb942c54f36"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("10c4e61b-964e-41bb-aebf-c893009e419e"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("237cf253-2f77-42f0-a063-68f9aa3b32a1"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("4a45aeb5-e5c2-4390-a1c0-74d578a4ecab"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("501620f1-cc07-41c5-bcaf-fd62d3604e68"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("5c2d9e44-32eb-447a-9f8e-229acc8c8e28"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("94aa89ad-ada6-4729-bfe1-ee702226ed16"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("a6e59933-3c72-42fe-9554-eddf0abded43"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("d297dfd5-7396-4541-8930-34275b6f4cd3"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("e69c89f0-aab4-4728-9f3b-7228a11371d5"));

            migrationBuilder.DeleteData(
                table: "precios",
                keyColumn: "Id",
                keyValue: new Guid("2f000dc4-eab4-412c-9458-5da55cef6b40"));

            migrationBuilder.AddColumn<string>(
                name: "PublicId",
                table: "imagenes",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: "b6080e42-a9f6-477a-8dfe-672c18a7adc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: "b6080e42-a9f6-477a-8dfe-672c18a7adc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleId",
                value: "b6080e42-a9f6-477a-8dfe-672c18a7adc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoleId",
                value: "b6080e42-a9f6-477a-8dfe-672c18a7adc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoleId",
                value: "b6080e42-a9f6-477a-8dfe-672c18a7adc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoleId",
                value: "b6080e42-a9f6-477a-8dfe-672c18a7adc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7,
                column: "RoleId",
                value: "b6080e42-a9f6-477a-8dfe-672c18a7adc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8,
                column: "RoleId",
                value: "b6080e42-a9f6-477a-8dfe-672c18a7adc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9,
                column: "RoleId",
                value: "b6080e42-a9f6-477a-8dfe-672c18a7adc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoleId",
                value: "b6080e42-a9f6-477a-8dfe-672c18a7adc7");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoleId",
                value: "85987d33-20aa-4c38-952f-ae81e4563d4c");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoleId",
                value: "85987d33-20aa-4c38-952f-ae81e4563d4c");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoleId",
                value: "85987d33-20aa-4c38-952f-ae81e4563d4c");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14,
                column: "RoleId",
                value: "85987d33-20aa-4c38-952f-ae81e4563d4c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "85987d33-20aa-4c38-952f-ae81e4563d4c", null, "CLIENT", "CLIENT" },
                    { "b6080e42-a9f6-477a-8dfe-672c18a7adc7", null, "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "cursos",
                columns: new[] { "Id", "Descripcion", "FechaPublicacion", "Titulo" },
                values: new object[,]
                {
                    { new Guid("1ee31a7d-7ec2-4263-b4bb-dca190dc3368"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2026, 6, 2, 16, 34, 36, 826, DateTimeKind.Utc).AddTicks(6172), "Incredible Wooden Computer" },
                    { new Guid("2dd27df0-b376-4898-b713-54f9dd9f3b05"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(2026, 6, 2, 16, 34, 36, 826, DateTimeKind.Utc).AddTicks(6218), "Ergonomic Cotton Shirt" },
                    { new Guid("36c81edc-2f80-4c33-b576-1bb7205d6f5f"), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", new DateTime(2026, 6, 2, 16, 34, 36, 826, DateTimeKind.Utc).AddTicks(6138), "Unbranded Concrete Fish" },
                    { new Guid("43b3aea1-367d-47bb-a3e6-0d8a39e1824c"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2026, 6, 2, 16, 34, 36, 826, DateTimeKind.Utc).AddTicks(6226), "Rustic Frozen Bacon" },
                    { new Guid("524fd4fb-5d95-442a-b015-81b56fb9c0b6"), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(2026, 6, 2, 16, 34, 36, 826, DateTimeKind.Utc).AddTicks(6210), "Sleek Fresh Cheese" },
                    { new Guid("6a440851-239d-4305-84b0-66eaf488edef"), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(2026, 6, 2, 16, 34, 36, 826, DateTimeKind.Utc).AddTicks(6197), "Ergonomic Steel Bacon" },
                    { new Guid("7445a139-82b8-4934-bd32-c38ecbfc61dd"), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(2026, 6, 2, 16, 34, 36, 826, DateTimeKind.Utc).AddTicks(6161), "Small Steel Chair" },
                    { new Guid("8977c9d7-4b9c-444c-a555-c4b8918871cb"), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(2026, 6, 2, 16, 34, 36, 826, DateTimeKind.Utc).AddTicks(6184), "Unbranded Fresh Shirt" },
                    { new Guid("8f4e4a50-2917-495d-a5cd-b4ef44b26431"), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(2026, 6, 2, 16, 34, 36, 826, DateTimeKind.Utc).AddTicks(5832), "Licensed Wooden Bacon" }
                });

            migrationBuilder.InsertData(
                table: "instructores",
                columns: new[] { "Id", "Apellidos", "Grado", "Nombre" },
                values: new object[,]
                {
                    { new Guid("05c31469-40d0-48d8-b1aa-4537fc8694f2"), "Johns", "Dynamic Solutions Facilitator", "Trent" },
                    { new Guid("1b0ea8d3-5df6-428a-9a5a-0f6f4bfcb3e9"), "Rolfson", "District Security Consultant", "Gabriella" },
                    { new Guid("3d9f4f36-4d37-40be-987b-cbcabe1e7a59"), "Hickle", "Customer Identity Representative", "Mavis" },
                    { new Guid("5703b9f9-84ef-4999-8ebc-1d7b873db3cf"), "Nicolas", "District Markets Orchestrator", "Virginia" },
                    { new Guid("828e32c1-5b25-433a-819b-d3b5c7650bc7"), "Brekke", "Investor Division Orchestrator", "Tania" },
                    { new Guid("849eba76-c1c7-42db-acf7-ad5199674649"), "Smitham", "Dynamic Program Developer", "Queen" },
                    { new Guid("a8ca6cec-21c7-497a-b99e-7d8ea010dff2"), "Wisozk", "Forward Solutions Developer", "Ella" },
                    { new Guid("cb58aba4-cab6-4626-acf1-ba8f7916d8c4"), "Kuphal", "International Infrastructure Facilitator", "Rebeka" },
                    { new Guid("d1f0624c-0148-4765-a2c4-1c55b1f5bdb0"), "Wunsch", "Investor Group Developer", "Johnny" },
                    { new Guid("ff2e127b-9762-4039-b507-56dbff73c331"), "Spencer", "Direct Marketing Administrator", "Millie" }
                });

            migrationBuilder.InsertData(
                table: "precios",
                columns: new[] { "Id", "Nombre", "PrecioActual", "PrecioPromocion" },
                values: new object[] { new Guid("71a4ce8a-341d-4846-a34c-bded74705cef"), "Precio Regular", 10.0m, 8.0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85987d33-20aa-4c38-952f-ae81e4563d4c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6080e42-a9f6-477a-8dfe-672c18a7adc7");

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("1ee31a7d-7ec2-4263-b4bb-dca190dc3368"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("2dd27df0-b376-4898-b713-54f9dd9f3b05"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("36c81edc-2f80-4c33-b576-1bb7205d6f5f"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("43b3aea1-367d-47bb-a3e6-0d8a39e1824c"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("524fd4fb-5d95-442a-b015-81b56fb9c0b6"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("6a440851-239d-4305-84b0-66eaf488edef"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("7445a139-82b8-4934-bd32-c38ecbfc61dd"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("8977c9d7-4b9c-444c-a555-c4b8918871cb"));

            migrationBuilder.DeleteData(
                table: "cursos",
                keyColumn: "Id",
                keyValue: new Guid("8f4e4a50-2917-495d-a5cd-b4ef44b26431"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("05c31469-40d0-48d8-b1aa-4537fc8694f2"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("1b0ea8d3-5df6-428a-9a5a-0f6f4bfcb3e9"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("3d9f4f36-4d37-40be-987b-cbcabe1e7a59"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("5703b9f9-84ef-4999-8ebc-1d7b873db3cf"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("828e32c1-5b25-433a-819b-d3b5c7650bc7"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("849eba76-c1c7-42db-acf7-ad5199674649"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("a8ca6cec-21c7-497a-b99e-7d8ea010dff2"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("cb58aba4-cab6-4626-acf1-ba8f7916d8c4"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("d1f0624c-0148-4765-a2c4-1c55b1f5bdb0"));

            migrationBuilder.DeleteData(
                table: "instructores",
                keyColumn: "Id",
                keyValue: new Guid("ff2e127b-9762-4039-b507-56dbff73c331"));

            migrationBuilder.DeleteData(
                table: "precios",
                keyColumn: "Id",
                keyValue: new Guid("71a4ce8a-341d-4846-a34c-bded74705cef"));

            migrationBuilder.DropColumn(
                name: "PublicId",
                table: "imagenes");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "RoleId",
                value: "56c09327-b80d-4ef2-8f2d-b5a9c5f508a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "RoleId",
                value: "56c09327-b80d-4ef2-8f2d-b5a9c5f508a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3,
                column: "RoleId",
                value: "56c09327-b80d-4ef2-8f2d-b5a9c5f508a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoleId",
                value: "56c09327-b80d-4ef2-8f2d-b5a9c5f508a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoleId",
                value: "56c09327-b80d-4ef2-8f2d-b5a9c5f508a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoleId",
                value: "56c09327-b80d-4ef2-8f2d-b5a9c5f508a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7,
                column: "RoleId",
                value: "56c09327-b80d-4ef2-8f2d-b5a9c5f508a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8,
                column: "RoleId",
                value: "56c09327-b80d-4ef2-8f2d-b5a9c5f508a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9,
                column: "RoleId",
                value: "56c09327-b80d-4ef2-8f2d-b5a9c5f508a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoleId",
                value: "56c09327-b80d-4ef2-8f2d-b5a9c5f508a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11,
                column: "RoleId",
                value: "12eb52e1-b752-4201-ba7a-cd0c9d11741a");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoleId",
                value: "12eb52e1-b752-4201-ba7a-cd0c9d11741a");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoleId",
                value: "12eb52e1-b752-4201-ba7a-cd0c9d11741a");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14,
                column: "RoleId",
                value: "12eb52e1-b752-4201-ba7a-cd0c9d11741a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12eb52e1-b752-4201-ba7a-cd0c9d11741a", null, "CLIENT", "CLIENT" },
                    { "56c09327-b80d-4ef2-8f2d-b5a9c5f508a2", null, "ADMIN", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "cursos",
                columns: new[] { "Id", "Descripcion", "FechaPublicacion", "Titulo" },
                values: new object[,]
                {
                    { new Guid("3e28b445-70ef-4883-976a-2d8877a17135"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(2026, 5, 23, 17, 11, 30, 378, DateTimeKind.Utc).AddTicks(8977), "Handcrafted Steel Cheese" },
                    { new Guid("6003c89c-9950-4ad3-8ede-586b578e37ce"), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", new DateTime(2026, 5, 23, 17, 11, 30, 378, DateTimeKind.Utc).AddTicks(8946), "Practical Rubber Pizza" },
                    { new Guid("61ade3ef-d6ba-4973-95bd-d8508dd9da6f"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(2026, 5, 23, 17, 11, 30, 378, DateTimeKind.Utc).AddTicks(8986), "Sleek Granite Soap" },
                    { new Guid("a050a136-a093-45e7-b868-ccef76367016"), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", new DateTime(2026, 5, 23, 17, 11, 30, 378, DateTimeKind.Utc).AddTicks(9014), "Awesome Rubber Shoes" },
                    { new Guid("a6d2f52f-c918-4a99-9c83-dfe504bf9f92"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(2026, 5, 23, 17, 11, 30, 378, DateTimeKind.Utc).AddTicks(9045), "Generic Steel Table" },
                    { new Guid("b2e838a8-6678-4ac0-9382-4826c11634eb"), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", new DateTime(2026, 5, 23, 17, 11, 30, 378, DateTimeKind.Utc).AddTicks(8999), "Small Concrete Mouse" },
                    { new Guid("c5105bc7-3794-4425-bca5-fef25886600b"), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(2026, 5, 23, 17, 11, 30, 378, DateTimeKind.Utc).AddTicks(8966), "Ergonomic Wooden Bike" },
                    { new Guid("ede29c81-a20e-4f68-abcc-7edcfe440073"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(2026, 5, 23, 17, 11, 30, 378, DateTimeKind.Utc).AddTicks(9024), "Rustic Cotton Chair" },
                    { new Guid("f1960fc1-5be7-40f2-b1c3-a48c2cd18930"), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", new DateTime(2026, 5, 23, 17, 11, 30, 378, DateTimeKind.Utc).AddTicks(8586), "Ergonomic Metal Shoes" }
                });

            migrationBuilder.InsertData(
                table: "instructores",
                columns: new[] { "Id", "Apellidos", "Grado", "Nombre" },
                values: new object[,]
                {
                    { new Guid("0deceb3a-44e0-4953-a026-abb942c54f36"), "Mohr", "Investor Interactions Consultant", "Mekhi" },
                    { new Guid("10c4e61b-964e-41bb-aebf-c893009e419e"), "Gerhold", "Global Identity Supervisor", "Nikki" },
                    { new Guid("237cf253-2f77-42f0-a063-68f9aa3b32a1"), "Fahey", "Forward Tactics Strategist", "Evangeline" },
                    { new Guid("4a45aeb5-e5c2-4390-a1c0-74d578a4ecab"), "Zulauf", "Lead Solutions Specialist", "Milan" },
                    { new Guid("501620f1-cc07-41c5-bcaf-fd62d3604e68"), "Gibson", "Human Marketing Associate", "Alvina" },
                    { new Guid("5c2d9e44-32eb-447a-9f8e-229acc8c8e28"), "Fadel", "Legacy Assurance Engineer", "Franz" },
                    { new Guid("94aa89ad-ada6-4729-bfe1-ee702226ed16"), "Lang", "Product Mobility Planner", "Steve" },
                    { new Guid("a6e59933-3c72-42fe-9554-eddf0abded43"), "Homenick", "Human Integration Orchestrator", "Kendrick" },
                    { new Guid("d297dfd5-7396-4541-8930-34275b6f4cd3"), "Gibson", "International Accountability Officer", "Kacey" },
                    { new Guid("e69c89f0-aab4-4728-9f3b-7228a11371d5"), "Reichert", "Dynamic Mobility Facilitator", "Alvis" }
                });

            migrationBuilder.InsertData(
                table: "precios",
                columns: new[] { "Id", "Nombre", "PrecioActual", "PrecioPromocion" },
                values: new object[] { new Guid("2f000dc4-eab4-412c-9458-5da55cef6b40"), "Precio Regular", 10.0m, 8.0m });
        }
    }
}
