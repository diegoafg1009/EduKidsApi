using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduKidsApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "DIFFICULTIES",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DIFFICULTIES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MATTERS",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MATTERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ROLES",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TOPICS",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DifficultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MatterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TOPICS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TOPICS_DIFFICULTIES_DifficultId",
                        column: x => x.DifficultId,
                        principalSchema: "dbo",
                        principalTable: "DIFFICULTIES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TOPICS_MATTERS_MatterId",
                        column: x => x.MatterId,
                        principalSchema: "dbo",
                        principalTable: "MATTERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ROLE_CLAIMS",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_CLAIMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ROLE_CLAIMS_ROLES_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "ROLES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RESPONSES",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESPONSES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RESPONSES_USERS_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_CLAIMS",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_CLAIMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_CLAIMS_USERS_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_LOGINS",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_LOGINS", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_USER_LOGINS_USERS_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_ROLES",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ROLES", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_USER_ROLES_ROLES_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "ROLES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_ROLES_USERS_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_TOKENS",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_TOKENS", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_USER_TOKENS_USERS_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QUESTIONS",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUESTIONS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QUESTIONS_TOPICS_TopicId",
                        column: x => x.TopicId,
                        principalSchema: "dbo",
                        principalTable: "TOPICS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ALTERNATIVES",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "BIT", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALTERNATIVES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ALTERNATIVES_QUESTIONS_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "dbo",
                        principalTable: "QUESTIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RESPONSE_DETAILS",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ResponseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AlternativeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RESPONSE_DETAILS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RESPONSE_DETAILS_ALTERNATIVES_AlternativeId",
                        column: x => x.AlternativeId,
                        principalSchema: "dbo",
                        principalTable: "ALTERNATIVES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RESPONSE_DETAILS_QUESTIONS_QuestionId",
                        column: x => x.QuestionId,
                        principalSchema: "dbo",
                        principalTable: "QUESTIONS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RESPONSE_DETAILS_RESPONSES_ResponseId",
                        column: x => x.ResponseId,
                        principalSchema: "dbo",
                        principalTable: "RESPONSES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALTERNATIVES_QuestionId",
                schema: "dbo",
                table: "ALTERNATIVES",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QUESTIONS_TopicId",
                schema: "dbo",
                table: "QUESTIONS",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_RESPONSE_DETAILS_AlternativeId",
                schema: "dbo",
                table: "RESPONSE_DETAILS",
                column: "AlternativeId");

            migrationBuilder.CreateIndex(
                name: "IX_RESPONSE_DETAILS_QuestionId",
                schema: "dbo",
                table: "RESPONSE_DETAILS",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_RESPONSE_DETAILS_ResponseId",
                schema: "dbo",
                table: "RESPONSE_DETAILS",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_RESPONSES_UserId",
                schema: "dbo",
                table: "RESPONSES",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ROLE_CLAIMS_RoleId",
                schema: "dbo",
                table: "ROLE_CLAIMS",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "ROLES",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TOPICS_DifficultId",
                schema: "dbo",
                table: "TOPICS",
                column: "DifficultId");

            migrationBuilder.CreateIndex(
                name: "IX_TOPICS_MatterId",
                schema: "dbo",
                table: "TOPICS",
                column: "MatterId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_CLAIMS_UserId",
                schema: "dbo",
                table: "USER_CLAIMS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_LOGINS_UserId",
                schema: "dbo",
                table: "USER_LOGINS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLES_RoleId",
                schema: "dbo",
                table: "USER_ROLES",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "USERS",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "USERS",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RESPONSE_DETAILS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ROLE_CLAIMS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "USER_CLAIMS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "USER_LOGINS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "USER_ROLES",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "USER_TOKENS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ALTERNATIVES",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RESPONSES",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ROLES",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "QUESTIONS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "USERS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TOPICS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DIFFICULTIES",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MATTERS",
                schema: "dbo");
        }
    }
}
