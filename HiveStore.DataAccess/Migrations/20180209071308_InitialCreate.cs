using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HiveStore.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "hive");

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "hive",
                columns: table => new
                {
                    EMPLOYEE_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ADDRESS = table.Column<string>(maxLength: 200, nullable: true),
                    CITY = table.Column<string>(maxLength: 200, nullable: true),
                    COUNTRY = table.Column<string>(maxLength: 200, nullable: true),
                    CREATED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    FIRST_NAME = table.Column<string>(maxLength: 200, nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false),
                    LAST_NAME = table.Column<string>(maxLength: 200, nullable: false),
                    MODIFIED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(nullable: false),
                    RTS = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EMPLOYEE_ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "hive",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false),
                    MODIFIED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(nullable: false),
                    PRODUCT_NAME = table.Column<string>(maxLength: 200, nullable: false),
                    RTS = table.Column<byte[]>(rowVersion: true, nullable: false),
                    UNIT_PRICE = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.PRODUCT_ID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "hive",
                columns: table => new
                {
                    ORDER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    EMPLOYEE_ID = table.Column<int>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false),
                    MODIFIED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(nullable: false),
                    RTS = table.Column<byte[]>(rowVersion: true, nullable: false),
                    REQUIRED_DATE = table.Column<DateTime>(nullable: false),
                    SHIP_ADDRESS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ORDER_ID);
                    table.ForeignKey(
                        name: "FK_Order_Employee_EMPLOYEE_ID",
                        column: x => x.EMPLOYEE_ID,
                        principalSchema: "hive",
                        principalTable: "Employee",
                        principalColumn: "EMPLOYEE_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                schema: "hive",
                columns: table => new
                {
                    ORDER_DETAILS_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CREATED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    DISCOUNT = table.Column<decimal>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false),
                    MODIFIED_BY = table.Column<string>(maxLength: 50, nullable: false),
                    MODIFIED_DATE = table.Column<DateTime>(nullable: false),
                    ORDER_ID = table.Column<int>(nullable: false),
                    PRODUCT_ID = table.Column<int>(nullable: false),
                    QUANTITY = table.Column<int>(nullable: false),
                    RTS = table.Column<byte[]>(rowVersion: true, nullable: false),
                    UNIT_PRICE = table.Column<decimal>(nullable: false)
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
                name: "IX_Order_EMPLOYEE_ID",
                schema: "hive",
                table: "Order",
                column: "EMPLOYEE_ID");

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
                name: "OrderDetails",
                schema: "hive");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "hive");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "hive");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "hive");
        }
    }
}
