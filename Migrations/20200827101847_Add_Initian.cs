using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace SafeCity2607last.Migrations
{
    public partial class Add_Initian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         

           

            migrationBuilder.AddColumn<string>(
                name: "AdressePostale",
                table: "UserProfile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CIN",
                table: "UserProfile",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Datedebut",
                table: "UserProfile",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Datefin",
                table: "UserProfile",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Phone1",
                table: "UserProfile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone2",
                table: "UserProfile",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ville",
                table: "UserProfile",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdressePostale",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "CIN",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "Datedebut",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "Datefin",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "Phone1",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "Phone2",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "Ville",
                table: "UserProfile");

            migrationBuilder.CreateTable(
                name: "Bill",
                columns: table => new
                {
                    BillId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BillDate = table.Column<DateTimeOffset>(nullable: false),
                    BillDueDate = table.Column<DateTimeOffset>(nullable: false),
                    BillName = table.Column<string>(nullable: true),
                    BillTypeId = table.Column<int>(nullable: false),
                    GoodsReceivedNoteId = table.Column<int>(nullable: false),
                    VendorDONumber = table.Column<string>(nullable: true),
                    VendorInvoiceNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.BillId);
                });

            migrationBuilder.CreateTable(
                name: "DateDébutFinAdmin",
                columns: table => new
                {
                    SalesOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    CustomerRefNumber = table.Column<string>(nullable: true),
                    DeliveryDate = table.Column<DateTimeOffset>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    Freight = table.Column<double>(nullable: false),
                    OrderDate = table.Column<DateTimeOffset>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    SalesOrderName = table.Column<string>(nullable: true),
                    SalesTypeId = table.Column<int>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    Tax = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateDébutFinAdmin", x => x.SalesOrderId);
                });

            migrationBuilder.CreateTable(
                name: "DateDébutFinControleurQ",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    DeliveryDate = table.Column<DateTimeOffset>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    Freight = table.Column<double>(nullable: false),
                    OrderDate = table.Column<DateTimeOffset>(nullable: false),
                    PurchaseOrderName = table.Column<string>(nullable: true),
                    PurchaseTypeId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    SubTotal = table.Column<double>(nullable: false),
                    Tax = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    VendorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateDébutFinControleurQ", x => x.PurchaseOrderId);
                });

            migrationBuilder.CreateTable(
                name: "Grade",
                columns: table => new
                {
                    CurrencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrencyCode = table.Column<string>(nullable: false),
                    CurrencyName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grade", x => x.CurrencyId);
                });

            migrationBuilder.CreateTable(
                name: "InfoMessageCQ",
                columns: table => new
                {
                    PaymentvoucherId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BillId = table.Column<int>(nullable: false),
                    CashBankId = table.Column<int>(nullable: false),
                    IsFullPayment = table.Column<bool>(nullable: false),
                    PaymentAmount = table.Column<double>(nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(nullable: false),
                    PaymentTypeId = table.Column<int>(nullable: false),
                    PaymentVoucherName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoMessageCQ", x => x.PaymentvoucherId);
                });

            migrationBuilder.CreateTable(
                name: "InfoPublicationControleurQ",
                columns: table => new
                {
                    GoodsReceivedNoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GRNDate = table.Column<DateTimeOffset>(nullable: false),
                    GoodsReceivedNoteName = table.Column<string>(nullable: true),
                    IsFullReceive = table.Column<bool>(nullable: false),
                    PurchaseOrderId = table.Column<int>(nullable: false),
                    VendorDONumber = table.Column<string>(nullable: true),
                    VendorInvoiceNumber = table.Column<string>(nullable: true),
                    WarehouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoPublicationControleurQ", x => x.GoodsReceivedNoteId);
                });

            migrationBuilder.CreateTable(
                name: "InfosPublicationsAdmin",
                columns: table => new
                {
                    ShipmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsFullShipment = table.Column<bool>(nullable: false),
                    SalesOrderId = table.Column<int>(nullable: false),
                    ShipmentDate = table.Column<DateTimeOffset>(nullable: false),
                    ShipmentName = table.Column<string>(nullable: true),
                    ShipmentTypeId = table.Column<int>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfosPublicationsAdmin", x => x.ShipmentId);
                });

            migrationBuilder.CreateTable(
                name: "Lieu",
                columns: table => new
                {
                    WarehouseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    WarehouseName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lieu", x => x.WarehouseId);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceDate = table.Column<DateTimeOffset>(nullable: false),
                    InvoiceDueDate = table.Column<DateTimeOffset>(nullable: false),
                    InvoiceName = table.Column<string>(nullable: true),
                    InvoiceTypeId = table.Column<int>(nullable: false),
                    ShipmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.InvoiceId);
                });

            migrationBuilder.CreateTable(
                name: "Mission",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    BranchName = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mission", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentReceive",
                columns: table => new
                {
                    PaymentReceiveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceId = table.Column<int>(nullable: false),
                    IsFullPayment = table.Column<bool>(nullable: false),
                    PaymentAmount = table.Column<double>(nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(nullable: false),
                    PaymentReceiveName = table.Column<string>(nullable: true),
                    PaymentTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentReceive", x => x.PaymentReceiveId);
                });

            migrationBuilder.CreateTable(
                name: "PropositionsAdmin",
                columns: table => new
                {
                    SalesTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    SalesTypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropositionsAdmin", x => x.SalesTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PropositionsControleurQualité",
                columns: table => new
                {
                    PurchaseTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    PurchaseTypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropositionsControleurQualité", x => x.PurchaseTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PublicationChercheurs",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Barcode = table.Column<string>(nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    DefaultBuyingPrice = table.Column<double>(nullable: false),
                    DefaultSellingPrice = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProductCode = table.Column<string>(nullable: true),
                    ProductImageUrl = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: false),
                    UnitOfMeasureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationChercheurs", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "SujetPublication",
                columns: table => new
                {
                    UnitOfMeasureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    UnitOfMeasureName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SujetPublication", x => x.UnitOfMeasureId);
                });

            migrationBuilder.CreateTable(
                name: "TypeAdmin",
                columns: table => new
                {
                    CustomerTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerTypeName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAdmin", x => x.CustomerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TypeControleurQualité",
                columns: table => new
                {
                    VendorTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    VendorTypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeControleurQualité", x => x.VendorTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TypeMessage",
                columns: table => new
                {
                    InvoiceTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    InvoiceTypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMessage", x => x.InvoiceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TypeProposition",
                columns: table => new
                {
                    BillTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BillTypeName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeProposition", x => x.BillTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DateDébutFinAdminLine",
                columns: table => new
                {
                    SalesOrderLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DiscountAmount = table.Column<double>(nullable: false),
                    DiscountPercentage = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    SalesOrderId = table.Column<int>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    TaxAmount = table.Column<double>(nullable: false),
                    TaxPercentage = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateDébutFinAdminLine", x => x.SalesOrderLineId);
                    table.ForeignKey(
                        name: "FK_DateDébutFinAdminLine_DateDébutFinAdmin_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "DateDébutFinAdmin",
                        principalColumn: "SalesOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DateDébutFinControleurQLine",
                columns: table => new
                {
                    PurchaseOrderLineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DiscountAmount = table.Column<double>(nullable: false),
                    DiscountPercentage = table.Column<double>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    PurchaseOrderId = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    TaxAmount = table.Column<double>(nullable: false),
                    TaxPercentage = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateDébutFinControleurQLine", x => x.PurchaseOrderLineId);
                    table.ForeignKey(
                        name: "FK_DateDébutFinControleurQLine_DateDébutFinControleurQ_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "DateDébutFinControleurQ",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DateDébutFinAdminLine_SalesOrderId",
                table: "DateDébutFinAdminLine",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DateDébutFinControleurQLine_PurchaseOrderId",
                table: "DateDébutFinControleurQLine",
                column: "PurchaseOrderId");
        }
    }
}
