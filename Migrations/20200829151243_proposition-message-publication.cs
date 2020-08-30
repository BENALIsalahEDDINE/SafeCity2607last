using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SafeCity2607last.Migrations
{
    public partial class propositionmessagepublication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Proposition",
                newName: "Ville");

            migrationBuilder.RenameColumn(
                name: "CashBankName",
                table: "Proposition",
                newName: "Propositionn");

            migrationBuilder.RenameColumn(
                name: "CashBankId",
                table: "Proposition",
                newName: "Id_Prop");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Date",
                table: "Proposition",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Heure",
                table: "Proposition",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "Id_Com",
                table: "Proposition",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id_Source",
                table: "Proposition",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MessageAuPublic",
                columns: table => new
                {
                    Id_Mes = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<string>(nullable: true),
                    Heure = table.Column<string>(nullable: true),
                    Id_Com = table.Column<string>(nullable: true),
                    Id_Source = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Ville = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageAuPublic", x => x.Id_Mes);
                });

            migrationBuilder.CreateTable(
                name: "MessagePersonnalise",
                columns: table => new
                {
                    Id_Mes = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<string>(nullable: true),
                    Heure = table.Column<string>(nullable: true),
                    Id_Com = table.Column<string>(nullable: true),
                    Id_Source = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Ville = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagePersonnalise", x => x.Id_Mes);
                });

            migrationBuilder.CreateTable(
                name: "MessageRecu",
                columns: table => new
                {
                    Id_Mes = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<string>(nullable: true),
                    Heure = table.Column<string>(nullable: true),
                    Id_Com = table.Column<string>(nullable: true),
                    Id_Source = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Ville = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageRecu", x => x.Id_Mes);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageAuPublic");

            migrationBuilder.DropTable(
                name: "MessagePersonnalise");

            migrationBuilder.DropTable(
                name: "MessageRecu");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Proposition");

            migrationBuilder.DropColumn(
                name: "Heure",
                table: "Proposition");

            migrationBuilder.DropColumn(
                name: "Id_Com",
                table: "Proposition");

            migrationBuilder.DropColumn(
                name: "Id_Source",
                table: "Proposition");

            migrationBuilder.RenameColumn(
                name: "Ville",
                table: "Proposition",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Propositionn",
                table: "Proposition",
                newName: "CashBankName");

            migrationBuilder.RenameColumn(
                name: "Id_Prop",
                table: "Proposition",
                newName: "CashBankId");
        }
    }
}
