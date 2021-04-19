using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JetShop_CarRent.Migrations
{
    public partial class Initialize_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IsRented = table.Column<bool>(type: "bit", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    CarModel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocialSercurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resevations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RentalCategory = table.Column<int>(type: "int", nullable: false),
                    BookingNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resevations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resevations_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarModel", "IsRented", "Mileage" },
                values: new object[,]
                {
                    { new Guid("a5bfa21d-d459-41d1-a715-fa6f74b374ee"), "Volvo 740", false, 27000 },
                    { new Guid("c655bdc4-94b7-472a-a065-663160ac1c66"), "Volvo V60", false, 10300 },
                    { new Guid("d793a92e-c704-4434-b219-b13f145176ca"), "Audi TT", false, 5600 },
                    { new Guid("ef8c5415-d3f8-4869-9788-7c15d5682be0"), "Audi Q4", false, 5123 },
                    { new Guid("9b69147e-c6b0-4f03-af79-e4c01584bda5"), "Toyota Yaris", false, 12551 },
                    { new Guid("a1bc58cf-3d01-457e-abd5-89845ae20714"), "Toyota Rav4", false, 125345 },
                    { new Guid("0e1fabc3-68fa-491e-9223-793efd4f8c4e"), "Volvo V40", false, 23561 },
                    { new Guid("32bc6d56-a17c-485f-bacb-fbcc0eb6eafa"), "Dodge Charger", false, 3451 },
                    { new Guid("1b8f4207-e872-4f87-bce0-bd9adc8bce6f"), "Lamborghini Gallardo", false, 8123 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resevations_CarId",
                table: "Resevations",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Resevations");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
