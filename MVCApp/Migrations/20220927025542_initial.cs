using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCApp.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Golongans",
                columns: table => new
                {
                    IdGolongan = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamaGolongan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Golongans", x => x.IdGolongan);
                });

            migrationBuilder.CreateTable(
                name: "Represtasis",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    uraian = table.Column<string>(nullable: true),
                    luarkota = table.Column<int>(nullable: false),
                    dalamkota = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Represtasis", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TiketPesawat",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    harga = table.Column<int>(nullable: false),
                    ruteAwal = table.Column<string>(nullable: true),
                    ruteTujuan = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiketPesawat", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UangHarian",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    provinsi = table.Column<string>(nullable: true),
                    luarkota = table.Column<int>(nullable: false),
                    dalamkota = table.Column<int>(nullable: false),
                    diklat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UangHarian", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pegawaii",
                columns: table => new
                {
                    idPegawai = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    namePegawai = table.Column<string>(nullable: true),
                    nipPegawai = table.Column<int>(nullable: false),
                    jabatanPegawai = table.Column<string>(nullable: true),
                    IdGolongan = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pegawaii", x => x.idPegawai);
                    table.ForeignKey(
                        name: "FK_Pegawaii_Golongans_IdGolongan",
                        column: x => x.IdGolongan,
                        principalTable: "Golongans",
                        principalColumn: "IdGolongan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pegawaii_IdGolongan",
                table: "Pegawaii",
                column: "IdGolongan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pegawaii");

            migrationBuilder.DropTable(
                name: "Represtasis");

            migrationBuilder.DropTable(
                name: "TiketPesawat");

            migrationBuilder.DropTable(
                name: "UangHarian");

            migrationBuilder.DropTable(
                name: "Golongans");
        }
    }
}
