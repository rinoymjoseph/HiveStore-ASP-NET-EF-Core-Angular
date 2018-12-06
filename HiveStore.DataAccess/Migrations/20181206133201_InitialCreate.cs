using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HiveStore.DataContext.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "HIVE");

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                schema: "HIVE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(nullable: false),
                    MODIFIED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false),
                    RTS = table.Column<byte[]>(rowVersion: true, nullable: false),
                    PRODUCT_NAME = table.Column<string>(maxLength: 200, nullable: false),
                    UNIT_PRICE = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ROLE",
                schema: "HIVE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(maxLength: 256, nullable: true),
                    NORMALIZED_NAME = table.Column<string>(maxLength: 256, nullable: true),
                    CONCURRENCY_STAMP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                schema: "HIVE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    USER_NAME = table.Column<string>(maxLength: 256, nullable: true),
                    NORMALIZED_USER_NAME = table.Column<string>(maxLength: 256, nullable: true),
                    EMAIL = table.Column<string>(maxLength: 256, nullable: true),
                    NORMALIZED_EMAIL = table.Column<string>(maxLength: 256, nullable: true),
                    EMAIL_CONFIRMED = table.Column<bool>(nullable: false),
                    PASSWORD_HASH = table.Column<string>(nullable: true),
                    SECURITY_STAMP = table.Column<string>(nullable: true),
                    CONCURRENCY_STAMP = table.Column<string>(nullable: true),
                    PHONE_NUMBER = table.Column<string>(nullable: true),
                    PHONE_NUMBER_CONFIRMED = table.Column<bool>(nullable: false),
                    TWO_FACTOR_ENABLED = table.Column<bool>(nullable: false),
                    LOCK_OUT_END = table.Column<DateTimeOffset>(nullable: true),
                    LOCK_OUT_ENABLED = table.Column<bool>(nullable: false),
                    ACCESS_FAILED_COUNT = table.Column<int>(nullable: false),
                    FIRST_NAME = table.Column<string>(maxLength: 200, nullable: false),
                    LAST_NAME = table.Column<string>(maxLength: 200, nullable: false),
                    ADDRESS = table.Column<string>(maxLength: 200, nullable: true),
                    CITY = table.Column<string>(maxLength: 200, nullable: true),
                    COUNTRY = table.Column<string>(maxLength: 200, nullable: true),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(nullable: false),
                    MODIFIED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER_SESSION",
                schema: "HIVE",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 449, nullable: false),
                    Value = table.Column<byte[]>(nullable: false),
                    ExpiresAtTime = table.Column<DateTimeOffset>(nullable: false),
                    SlidingExpirationInSeconds = table.Column<long>(nullable: true),
                    AbsoluteExpiration = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_SESSION", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ROLE_CLAIM",
                schema: "HIVE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ROLE_ID = table.Column<int>(nullable: false),
                    CLAIM_TYPE = table.Column<string>(nullable: true),
                    CLAIM_VALUE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_CLAIM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ROLE_CLAIM_ROLE_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalSchema: "HIVE",
                        principalTable: "ROLE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDER",
                schema: "HIVE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(nullable: false),
                    MODIFIED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false),
                    RTS = table.Column<byte[]>(rowVersion: true, nullable: false),
                    USER_ID = table.Column<int>(nullable: false),
                    REQUIRED_DATE = table.Column<DateTime>(nullable: false),
                    SHIP_ADDRESS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ORDER_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalSchema: "HIVE",
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_CLAIM",
                schema: "HIVE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    USER_ID = table.Column<int>(nullable: false),
                    CLAIM_TYPE = table.Column<string>(nullable: true),
                    CLAIM_VALUE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_CLAIM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_CLAIM_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalSchema: "HIVE",
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_LOGIN",
                schema: "HIVE",
                columns: table => new
                {
                    LOGIN_PROVIDER = table.Column<string>(nullable: false),
                    PROVIDER_KEY = table.Column<string>(nullable: false),
                    PROVIDER_DISPLAY_NAME = table.Column<string>(nullable: true),
                    USER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_LOGIN", x => new { x.LOGIN_PROVIDER, x.PROVIDER_KEY });
                    table.ForeignKey(
                        name: "FK_USER_LOGIN_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalSchema: "HIVE",
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_ROLE",
                schema: "HIVE",
                columns: table => new
                {
                    USER_ID = table.Column<int>(nullable: false),
                    ROLE_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_ROLE", x => new { x.USER_ID, x.ROLE_ID });
                    table.ForeignKey(
                        name: "FK_USER_ROLE_ROLE_ROLE_ID",
                        column: x => x.ROLE_ID,
                        principalSchema: "HIVE",
                        principalTable: "ROLE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_ROLE_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalSchema: "HIVE",
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_TOKEN",
                schema: "HIVE",
                columns: table => new
                {
                    USER_ID = table.Column<int>(nullable: false),
                    LOGIN_PROVIDER = table.Column<string>(nullable: false),
                    NAME = table.Column<string>(nullable: false),
                    VALUE = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_TOKEN", x => new { x.USER_ID, x.LOGIN_PROVIDER, x.NAME });
                    table.ForeignKey(
                        name: "FK_USER_TOKEN_USER_USER_ID",
                        column: x => x.USER_ID,
                        principalSchema: "HIVE",
                        principalTable: "USER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_DETAILS",
                schema: "HIVE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(nullable: false),
                    MODIFIED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false),
                    RTS = table.Column<byte[]>(rowVersion: true, nullable: false),
                    ORDER_ID = table.Column<int>(nullable: false),
                    PRODUCT_ID = table.Column<int>(nullable: false),
                    UNIT_PRICE = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    QUANTITY = table.Column<int>(nullable: false),
                    DISCOUNT = table.Column<decimal>(type: "decimal(2,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_DETAILS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ORDER_DETAILS_ORDER_ORDER_ID",
                        column: x => x.ORDER_ID,
                        principalSchema: "HIVE",
                        principalTable: "ORDER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_DETAILS_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalSchema: "HIVE",
                        principalTable: "PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_USER_ID",
                schema: "HIVE",
                table: "ORDER",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DETAILS_ORDER_ID",
                schema: "HIVE",
                table: "ORDER_DETAILS",
                column: "ORDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DETAILS_PRODUCT_ID",
                schema: "HIVE",
                table: "ORDER_DETAILS",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "HIVE",
                table: "ROLE",
                column: "NORMALIZED_NAME",
                unique: true,
                filter: "[NORMALIZED_NAME] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ROLE_CLAIM_ROLE_ID",
                schema: "HIVE",
                table: "ROLE_CLAIM",
                column: "ROLE_ID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "HIVE",
                table: "USER",
                column: "NORMALIZED_EMAIL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "HIVE",
                table: "USER",
                column: "NORMALIZED_USER_NAME",
                unique: true,
                filter: "[NORMALIZED_USER_NAME] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_USER_CLAIM_USER_ID",
                schema: "HIVE",
                table: "USER_CLAIM",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_LOGIN_USER_ID",
                schema: "HIVE",
                table: "USER_LOGIN",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_ROLE_ROLE_ID",
                schema: "HIVE",
                table: "USER_ROLE",
                column: "ROLE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ORDER_DETAILS",
                schema: "HIVE");

            migrationBuilder.DropTable(
                name: "ROLE_CLAIM",
                schema: "HIVE");

            migrationBuilder.DropTable(
                name: "USER_CLAIM",
                schema: "HIVE");

            migrationBuilder.DropTable(
                name: "USER_LOGIN",
                schema: "HIVE");

            migrationBuilder.DropTable(
                name: "USER_ROLE",
                schema: "HIVE");

            migrationBuilder.DropTable(
                name: "USER_SESSION",
                schema: "HIVE");

            migrationBuilder.DropTable(
                name: "USER_TOKEN",
                schema: "HIVE");

            migrationBuilder.DropTable(
                name: "ORDER",
                schema: "HIVE");

            migrationBuilder.DropTable(
                name: "PRODUCT",
                schema: "HIVE");

            migrationBuilder.DropTable(
                name: "ROLE",
                schema: "HIVE");

            migrationBuilder.DropTable(
                name: "USER",
                schema: "HIVE");
        }
    }
}
