using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SafeCity2607last.Migrations
{
    public partial class slh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

          

            

          
          


            migrationBuilder.CreateTable(
                name: "Chercheur",
                columns: table => new
                {
                    id_pub = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    date = table.Column<int>(nullable: false),
                    etat = table.Column<int>(nullable: false),
                    explication = table.Column<int>(nullable: false),
                    heure = table.Column<int>(nullable: false),
                    id_comment = table.Column<int>(nullable: false),
                    id_cq = table.Column<int>(nullable: false),
                    id_source = table.Column<string>(nullable: false),
                    lati = table.Column<int>(nullable: false),
                    longi = table.Column<int>(nullable: false),
                    pho1 = table.Column<int>(nullable: false),
                    pho2 = table.Column<int>(nullable: false),
                    pho3 = table.Column<int>(nullable: false),
                    publication = table.Column<int>(nullable: false),
                    rue = table.Column<int>(nullable: false),
                    secteur = table.Column<int>(nullable: false),
                    ville = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chercheur", x => x.id_pub);
                });

           

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

           

           

          

           

          

          

           


          
           

          


            

            


            migrationBuilder.CreateTable(
                name: "Publication",
                columns: table => new
                {
                    PaymentTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    PaymentTypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationPublic", x => x.PaymentTypeId);
                });

           

           

           

            

           

          

           
            
        }
    }
}
