using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud.Back.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instrument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrument", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Style",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Style", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdInstrument = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Instrument_IdInstrument",
                        column: x => x.IdInstrument,
                        principalTable: "Instrument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Band",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FormationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdStyle = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Band", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Band_Style_IdStyle",
                        column: x => x.IdStyle,
                        principalTable: "Style",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "BandMember",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdBand = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdMember = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BandMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BandMember_Band_IdBand",
                        column: x => x.IdBand,
                        principalTable: "Band",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_BandMember_Member_IdMember",
                        column: x => x.IdMember,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Band_IdStyle",
                table: "Band",
                column: "IdStyle");

            migrationBuilder.CreateIndex(
                name: "IX_BandMember_IdBand",
                table: "BandMember",
                column: "IdBand");

            migrationBuilder.CreateIndex(
                name: "IX_BandMember_IdMember",
                table: "BandMember",
                column: "IdMember");

            migrationBuilder.CreateIndex(
                name: "IX_Member_IdInstrument",
                table: "Member",
                column: "IdInstrument");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BandMember");

            migrationBuilder.DropTable(
                name: "Band");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Style");

            migrationBuilder.DropTable(
                name: "Instrument");
        }
    }
}
