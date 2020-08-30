using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SafeCity2607last.Migrations
{
    public partial class saah1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropColumn(
                name: "ShipmentTypeName",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "MessageRecu",
                newName: "Messagee");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Message",
                newName: "Ville");

            migrationBuilder.RenameColumn(
                name: "ShipmentTypeId",
                table: "Message",
                newName: "Id_Mes");

            migrationBuilder.AlterColumn<string>(
                name: "ville",
                table: "Publication",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "secteur",
                table: "Publication",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "rue",
                table: "Publication",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "publication",
                table: "Publication",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "pho3",
                table: "Publication",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "pho2",
                table: "Publication",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "pho1",
                table: "Publication",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "id_source",
                table: "Publication",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "heure",
                table: "Publication",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "explication",
                table: "Publication",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "etat",
                table: "Publication",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "date",
                table: "Publication",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Id_Source",
                table: "Proposition",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Id_Com",
                table: "Proposition",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Heure",
                table: "Proposition",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<int>(
                name: "Id_Source",
                table: "MessageRecu",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Id_Com",
                table: "MessageRecu",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Heure",
                table: "MessageRecu",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Date",
                table: "MessageRecu",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id_Source",
                table: "MessagePersonnalise",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Id_Com",
                table: "MessagePersonnalise",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Heure",
                table: "MessagePersonnalise",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Date",
                table: "MessagePersonnalise",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id_Source",
                table: "MessageAuPublic",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Id_Com",
                table: "MessageAuPublic",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Heure",
                table: "MessageAuPublic",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "Date",
                table: "MessageAuPublic",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Date",
                table: "Message",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTime>(
                name: "Heure",
                table: "Message",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id_Com",
                table: "Message",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Source",
                table: "Message",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Messagee",
                table: "Message",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CommentairesdePublic",
                columns: table => new
                {
                    CommentaireId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    NomCommentaire = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentairesdePublic", x => x.CommentaireId);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    id_pub = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTimeOffset>(nullable: false),
                    explication = table.Column<string>(nullable: true),
                    heure = table.Column<DateTime>(nullable: false),
                    id_comment = table.Column<int>(nullable: false),
                    id_cq = table.Column<int>(nullable: false),
                    id_source = table.Column<int>(nullable: false),
                    lati = table.Column<int>(nullable: false),
                    longi = table.Column<int>(nullable: false),
                    pho1 = table.Column<string>(nullable: true),
                    pho2 = table.Column<string>(nullable: true),
                    pho3 = table.Column<string>(nullable: true),
                    publication = table.Column<string>(nullable: true),
                    rue = table.Column<string>(nullable: true),
                    secteur = table.Column<string>(nullable: true),
                    ville = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.id_pub);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentairesdePublic");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "Heure",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "Id_Com",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "Id_Source",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "Messagee",
                table: "Message");

            migrationBuilder.RenameColumn(
                name: "Messagee",
                table: "MessageRecu",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "Ville",
                table: "Message",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Id_Mes",
                table: "Message",
                newName: "ShipmentTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "ville",
                table: "Publication",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "secteur",
                table: "Publication",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "rue",
                table: "Publication",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "publication",
                table: "Publication",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "pho3",
                table: "Publication",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "pho2",
                table: "Publication",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "pho1",
                table: "Publication",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "id_source",
                table: "Publication",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "heure",
                table: "Publication",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "explication",
                table: "Publication",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "etat",
                table: "Publication",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "date",
                table: "Publication",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<string>(
                name: "Id_Source",
                table: "Proposition",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Id_Com",
                table: "Proposition",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Heure",
                table: "Proposition",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Id_Source",
                table: "MessageRecu",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Id_Com",
                table: "MessageRecu",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Heure",
                table: "MessageRecu",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "MessageRecu",
                nullable: true,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<string>(
                name: "Id_Source",
                table: "MessagePersonnalise",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Id_Com",
                table: "MessagePersonnalise",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Heure",
                table: "MessagePersonnalise",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "MessagePersonnalise",
                nullable: true,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<string>(
                name: "Id_Source",
                table: "MessageAuPublic",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Id_Com",
                table: "MessageAuPublic",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Heure",
                table: "MessageAuPublic",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "MessageAuPublic",
                nullable: true,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AddColumn<string>(
                name: "ShipmentTypeName",
                table: "Message",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    ProductTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    ProductTypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.ProductTypeId);
                });
        }
    }
}
