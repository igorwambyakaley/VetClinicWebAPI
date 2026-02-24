using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VetClinicAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VetDoctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Specialty = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VetDoctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MicrochipId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Species = table.Column<string>(type: "TEXT", nullable: false),
                    VetDoctorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_VetDoctors_VetDoctorId",
                        column: x => x.VetDoctorId,
                        principalTable: "VetDoctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PetId = table.Column<int>(type: "INTEGER", nullable: false),
                    VetNotes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetProfiles_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "VetDoctors",
                columns: new[] { "Id", "Name", "Specialty" },
                values: new object[,]
                {
                    { 1, "Dr. Alice Smith", "Surgery" },
                    { 2, "Dr. Bob Johnson", "Dentistry" },
                    { 3, "Dr. Carol Lee", "Dermatology" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "MicrochipId", "Name", "Species", "VetDoctorId" },
                values: new object[,]
                {
                    { 1, "MC1001", "Buddy", "Dog", 1 },
                    { 2, "MC1002", "Whiskers", "Cat", 2 },
                    { 3, "MC1003", "Chirpy", "Bird", 3 },
                    { 4, "MC1004", "Nibbles", "Rabbit", 1 }
                });

            migrationBuilder.InsertData(
                table: "PetProfiles",
                columns: new[] { "Id", "PetId", "VetNotes" },
                values: new object[,]
                {
                    { 1, 1, "Healthy, needs annual vaccination." },
                    { 2, 2, "Dental cleaning scheduled next month." },
                    { 3, 3, "Feather condition normal, check diet." },
                    { 4, 4, "Monitor weight, eating well." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetProfiles_PetId",
                table: "PetProfiles",
                column: "PetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_VetDoctorId",
                table: "Pets",
                column: "VetDoctorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetProfiles");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "VetDoctors");
        }
    }
}
