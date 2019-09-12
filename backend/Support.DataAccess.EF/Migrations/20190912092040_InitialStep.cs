using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Support.DataAccess.EF.Migrations
{
    public partial class InitialStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sec");

            migrationBuilder.EnsureSchema(
                name: "gen");

            migrationBuilder.CreateTable(
                name: "Config",
                schema: "gen",
                columns: table => new
                {
                    ConfigId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConfigHdrId = table.Column<int>(nullable: true),
                    ConfigName = table.Column<string>(nullable: true),
                    ConfigValue = table.Column<int>(nullable: false),
                    ConfigNote = table.Column<string>(nullable: true),
                    ConfigSort = table.Column<int>(nullable: false),
                    ClassName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.ConfigId);
                    table.ForeignKey(
                        name: "FK_Config_Config_ConfigHdrId",
                        column: x => x.ConfigHdrId,
                        principalSchema: "gen",
                        principalTable: "Config",
                        principalColumn: "ConfigId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Access",
                schema: "sec",
                columns: table => new
                {
                    AccessId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessName = table.Column<string>(nullable: true),
                    AccessDesc = table.Column<string>(nullable: true),
                    IsGeneral = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Access", x => x.AccessId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "gen",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LoginName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<bool>(nullable: false),
                    Mobile = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_Config_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "gen",
                        principalTable: "Config",
                        principalColumn: "ConfigId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                schema: "gen",
                columns: table => new
                {
                    LogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    EntityName = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 2147483647, nullable: true),
                    ChangeTypeId = table.Column<int>(nullable: false),
                    PrimaryKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_Log_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "gen",
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Request",
                schema: "gen",
                columns: table => new
                {
                    RequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    RequestById = table.Column<int>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false),
                    PriorityId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AssignedId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Request", x => x.RequestId);
                    table.ForeignKey(
                        name: "FK_Request_Person_AssignedId",
                        column: x => x.AssignedId,
                        principalSchema: "gen",
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_Config_PriorityId",
                        column: x => x.PriorityId,
                        principalSchema: "gen",
                        principalTable: "Config",
                        principalColumn: "ConfigId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_Config_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "gen",
                        principalTable: "Config",
                        principalColumn: "ConfigId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Request_Person_RequestById",
                        column: x => x.RequestById,
                        principalSchema: "gen",
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_Config_StatusId",
                        column: x => x.StatusId,
                        principalSchema: "gen",
                        principalTable: "Config",
                        principalColumn: "ConfigId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Request_Config_TypeId",
                        column: x => x.TypeId,
                        principalSchema: "gen",
                        principalTable: "Config",
                        principalColumn: "ConfigId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccessPolicy",
                schema: "sec",
                columns: table => new
                {
                    AccessPolicyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessPolicy", x => x.AccessPolicyId);
                    table.ForeignKey(
                        name: "FK_AccessPolicy_Access_AccessId",
                        column: x => x.AccessId,
                        principalSchema: "sec",
                        principalTable: "Access",
                        principalColumn: "AccessId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccessPolicy_Person_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "gen",
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Response",
                schema: "gen",
                columns: table => new
                {
                    ResponseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResponseDate = table.Column<DateTime>(nullable: false),
                    CreateById = table.Column<int>(nullable: false),
                    RequestId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    Private = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_Response_Person_CreateById",
                        column: x => x.CreateById,
                        principalSchema: "gen",
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Response_Request_RequestId",
                        column: x => x.RequestId,
                        principalSchema: "gen",
                        principalTable: "Request",
                        principalColumn: "RequestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Config_ConfigHdrId",
                schema: "gen",
                table: "Config",
                column: "ConfigHdrId");

            migrationBuilder.CreateIndex(
                name: "IX_Log_PersonId",
                schema: "gen",
                table: "Log",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_StatusId",
                schema: "gen",
                table: "Person",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_AssignedId",
                schema: "gen",
                table: "Request",
                column: "AssignedId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_PriorityId",
                schema: "gen",
                table: "Request",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_ProjectId",
                schema: "gen",
                table: "Request",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_RequestById",
                schema: "gen",
                table: "Request",
                column: "RequestById");

            migrationBuilder.CreateIndex(
                name: "IX_Request_StatusId",
                schema: "gen",
                table: "Request",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Request_TypeId",
                schema: "gen",
                table: "Request",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_CreateById",
                schema: "gen",
                table: "Response",
                column: "CreateById");

            migrationBuilder.CreateIndex(
                name: "IX_Response_RequestId",
                schema: "gen",
                table: "Response",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessPolicy_AccessId",
                schema: "sec",
                table: "AccessPolicy",
                column: "AccessId");

            migrationBuilder.CreateIndex(
                name: "IX_AccessPolicy_PersonId",
                schema: "sec",
                table: "AccessPolicy",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log",
                schema: "gen");

            migrationBuilder.DropTable(
                name: "Response",
                schema: "gen");

            migrationBuilder.DropTable(
                name: "AccessPolicy",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "Request",
                schema: "gen");

            migrationBuilder.DropTable(
                name: "Access",
                schema: "sec");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "gen");

            migrationBuilder.DropTable(
                name: "Config",
                schema: "gen");
        }
    }
}
