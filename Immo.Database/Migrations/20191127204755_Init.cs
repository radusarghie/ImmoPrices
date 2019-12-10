using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Immo.Database.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyWebsites",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WebsiteRootUrl = table.Column<string>(nullable: true),
                    WebsitePropertyUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyWebsites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provinces_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HtmlPagedResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Html = table.Column<string>(nullable: true),
                    PageNumber = table.Column<int>(nullable: false),
                    PageSize = table.Column<int>(nullable: false),
                    AgencyId = table.Column<Guid>(nullable: false),
                    PropertyWebsiteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtmlPagedResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HtmlPagedResults_PropertyWebsites_PropertyWebsiteId",
                        column: x => x.PropertyWebsiteId,
                        principalTable: "PropertyWebsites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PostCode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProvinceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Towns_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    TownId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PropertyType = table.Column<int>(nullable: true),
                    ConstructionYear = table.Column<int>(nullable: true),
                    BedroomsNo = table.Column<int>(nullable: true),
                    FloorNo = table.Column<int>(nullable: true),
                    BathroomNo = table.Column<int>(nullable: true),
                    Garrages = table.Column<int>(nullable: true),
                    ParkingPlaces = table.Column<int>(nullable: true),
                    LivableSurface = table.Column<double>(nullable: true),
                    GroundSurface = table.Column<double>(nullable: true),
                    HasTerrace = table.Column<bool>(nullable: true),
                    HasGarden = table.Column<bool>(nullable: true),
                    Bedroom1Surface = table.Column<double>(nullable: true),
                    Bedroom2Surface = table.Column<double>(nullable: true),
                    Bedroom3Surface = table.Column<double>(nullable: true),
                    Bedroom4Surface = table.Column<double>(nullable: true),
                    Price = table.Column<double>(nullable: true),
                    EPC = table.Column<int>(nullable: true),
                    Pictures = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    OriginalURL = table.Column<string>(nullable: true),
                    AgencyId = table.Column<Guid>(nullable: false),
                    PropertyWebsiteId = table.Column<Guid>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_PropertyWebsites_PropertyWebsiteId",
                        column: x => x.PropertyWebsiteId,
                        principalTable: "PropertyWebsites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_TownId",
                table: "Addresses",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_HtmlPagedResults_PropertyWebsiteId",
                table: "HtmlPagedResults",
                column: "PropertyWebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_AddressId",
                table: "Properties",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertyWebsiteId",
                table: "Properties",
                column: "PropertyWebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Provinces_CountryId",
                table: "Provinces",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_ProvinceId",
                table: "Towns",
                column: "ProvinceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HtmlPagedResults");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "PropertyWebsites");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
