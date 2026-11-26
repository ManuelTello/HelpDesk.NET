using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDesk.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AuditoryModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorySummary_Users_UserId",
                table: "HistorySummary");

            migrationBuilder.DropIndex(
                name: "IX_HistorySummary_UserId",
                table: "HistorySummary");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HistorySummary");

            migrationBuilder.RenameColumn(
                name: "DateTimeCreated",
                table: "Tickets",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "DateTimeClosed",
                table: "Tickets",
                newName: "DateClosed");

            migrationBuilder.RenameColumn(
                name: "DateTimeCreated",
                table: "HistorySummary",
                newName: "DateCreated");

            migrationBuilder.AddColumn<Guid>(
                name: "ActorId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Auditory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRevoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Auditory_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OwnershipSummary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnershipSummary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnershipSummary_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnershipSummary_Users_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ActorId",
                table: "Tickets",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Auditory_UserId",
                table: "Auditory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnershipSummary_AgentId",
                table: "OwnershipSummary",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnershipSummary_TicketId",
                table: "OwnershipSummary",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_ActorId",
                table: "Tickets",
                column: "ActorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_ActorId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Auditory");

            migrationBuilder.DropTable(
                name: "OwnershipSummary");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ActorId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Tickets",
                newName: "DateTimeCreated");

            migrationBuilder.RenameColumn(
                name: "DateClosed",
                table: "Tickets",
                newName: "DateTimeClosed");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "HistorySummary",
                newName: "DateTimeCreated");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "HistorySummary",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_HistorySummary_UserId",
                table: "HistorySummary",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorySummary_Users_UserId",
                table: "HistorySummary",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
