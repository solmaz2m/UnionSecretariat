using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnionSecretariat.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Letters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LetterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SectionLkpId = table.Column<int>(type: "int", nullable: false),
                    SecretariatLkpId = table.Column<int>(type: "int", nullable: false),
                    ArrangementLkpId = table.Column<int>(type: "int", nullable: false),
                    LetterPriorityLkpId = table.Column<int>(type: "int", nullable: false),
                    LetterCopy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ForeignRecieverLkpId = table.Column<int>(type: "int", nullable: false),
                    RecieverLkpId = table.Column<int>(type: "int", nullable: false),
                    LetterRecieveKindLkpId = table.Column<int>(type: "int", nullable: false),
                    PostCompanyLkpId = table.Column<int>(type: "int", nullable: false),
                    PostKindLkpId = table.Column<int>(type: "int", nullable: false),
                    LetterNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AndikatorNumber = table.Column<int>(type: "int", nullable: false),
                    ReturnToNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttachmentCount = table.Column<int>(type: "int", nullable: false),
                    AttachmentTypeLkpIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondReciever = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoxDateTimePicker = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostBarcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecieveDateTimePicker = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LetterSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainLetterId = table.Column<int>(type: "int", nullable: false),
                    LetterDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuildId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LettersImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    objectID = table.Column<int>(type: "int", nullable: false),
                    OpTypes = table.Column<int>(type: "int", nullable: false),
                    Image1 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image2 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image3 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image4 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image5 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image6 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image7 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image8 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image9 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image10 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image11 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image12 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image13 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image14 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Image15 = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    LetterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LettersImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LettersImages_Letters_LetterId",
                        column: x => x.LetterId,
                        principalTable: "Letters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LettersImages_LetterId",
                table: "LettersImages",
                column: "LetterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LettersImages");

            migrationBuilder.DropTable(
                name: "Letters");
        }
    }
}
