using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObsApp.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Derslers",
                columns: table => new
                {
                    DersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DersAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DersKodu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Derslers", x => x.DersId);
                });

            migrationBuilder.CreateTable(
                name: "Siniflars",
                columns: table => new
                {
                    SinifId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SinifAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kontenjan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siniflars", x => x.SinifId);
                });

            migrationBuilder.CreateTable(
                name: "Ogrencilers",
                columns: table => new
                {
                    OgrenciId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OgrenciAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OgrenciSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OgrenciNumara = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SinifId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogrencilers", x => x.OgrenciId);
                    table.ForeignKey(
                        name: "FK_Ogrencilers_Siniflars_SinifId",
                        column: x => x.SinifId,
                        principalTable: "Siniflars",
                        principalColumn: "SinifId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OgrenciDerslers",
                columns: table => new
                {
                    OgrenciId = table.Column<int>(type: "int", nullable: false),
                    DersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OgrenciDerslers", x => new { x.OgrenciId, x.DersId });
                    table.ForeignKey(
                        name: "FK_OgrenciDerslers_Derslers_DersId",
                        column: x => x.DersId,
                        principalTable: "Derslers",
                        principalColumn: "DersId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OgrenciDerslers_Ogrencilers_OgrenciId",
                        column: x => x.OgrenciId,
                        principalTable: "Ogrencilers",
                        principalColumn: "OgrenciId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OgrenciDerslers_DersId",
                table: "OgrenciDerslers",
                column: "DersId");

            migrationBuilder.CreateIndex(
                name: "IX_Ogrencilers_SinifId",
                table: "Ogrencilers",
                column: "SinifId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OgrenciDerslers");

            migrationBuilder.DropTable(
                name: "Derslers");

            migrationBuilder.DropTable(
                name: "Ogrencilers");

            migrationBuilder.DropTable(
                name: "Siniflars");
        }
    }
}
