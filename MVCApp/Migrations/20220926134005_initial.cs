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
                name: "Pegawaii",
                columns: table => new
                {
                    idPegawai = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    namePegawai = table.Column<string>(nullable: true),
                    nipPegawai = table.Column<int>(nullable: false),
                    jabatanPegawai = table.Column<string>(nullable: true),
                    golonganPegawai = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pegawaii", x => x.idPegawai);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Golongans");

            migrationBuilder.DropTable(
                name: "Pegawaii");
        }
    }
}
