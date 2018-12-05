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
                name: "hive");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
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
                    USER_ID = table.Column<string>(nullable: false),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "hive",
                columns: table => new
                {
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(nullable: false),
                    MODIFIED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false),
                    RTS = table.Column<byte[]>(rowVersion: true, nullable: false),
                    PRODUCT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PRODUCT_NAME = table.Column<string>(maxLength: 200, nullable: false),
                    UNIT_PRICE = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.PRODUCT_ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "hive",
                columns: table => new
                {
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(nullable: false),
                    MODIFIED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false),
                    RTS = table.Column<byte[]>(rowVersion: true, nullable: false),
                    ORDER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    USER_ID = table.Column<string>(nullable: true),
                    REQUIRED_DATE = table.Column<DateTime>(nullable: false),
                    SHIP_ADDRESS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ORDER_ID);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_USER_ID",
                        column: x => x.USER_ID,
                        principalTable: "AspNetUsers",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                schema: "hive",
                columns: table => new
                {
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    CREATED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(nullable: false),
                    MODIFIED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false),
                    RTS = table.Column<byte[]>(rowVersion: true, nullable: false),
                    ORDER_DETAILS_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ORDER_ID = table.Column<int>(nullable: false),
                    PRODUCT_ID = table.Column<int>(nullable: false),
                    UNIT_PRICE = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    QUANTITY = table.Column<int>(nullable: false),
                    DISCOUNT = table.Column<decimal>(type: "decimal(2,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.ORDER_DETAILS_ID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order_ORDER_ID",
                        column: x => x.ORDER_ID,
                        principalSchema: "hive",
                        principalTable: "Order",
                        principalColumn: "ORDER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Product_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalSchema: "hive",
                        principalTable: "Product",
                        principalColumn: "PRODUCT_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NORMALIZED_EMAIL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NORMALIZED_USER_NAME",
                unique: true,
                filter: "[NORMALIZED_USER_NAME] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Order_USER_ID",
                schema: "hive",
                table: "Order",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ORDER_ID",
                schema: "hive",
                table: "OrderDetails",
                column: "ORDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_PRODUCT_ID",
                schema: "hive",
                table: "OrderDetails",
                column: "PRODUCT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderDetails",
                schema: "hive");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "hive");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "hive");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
