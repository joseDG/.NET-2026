using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TareasMVC.Migrations
{
    /// <inheritdoc />
    public partial class AdminRol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            IF NOT EXISTS(Select Id from AspNetRoles where Id = 'acf1d50c-849d-431b-abed-7902f9b56beb')
            BEGIN
	            INSERT AspNetRoles (Id, [Name], [NormalizedName])
	            VALUES ('acf1d50c-849d-431b-abed-7902f9b56beb', 'admin', 'ADMIN')
            END");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE AspNetRoles WHERE Id = 'acf1d50c-849d-431b-abed-7902f9b56beb'");
        }
    }
}
