using Microsoft.EntityFrameworkCore.Migrations;

namespace adet_mid_assignment_Espeleta_Michelle.Migrations
{
    public partial class updatingDescriptionToTaskDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "TaskDescription",
                table: "Tasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskDescription",
                table: "Tasks");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
