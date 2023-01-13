using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemEnergyHistoryModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemID = table.Column<string>(type: "TEXT", nullable: false),
                    Energy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemEnergyHistoryModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemGroupModel",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MaxLevel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemGroupModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemLevelHistoryModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemID = table.Column<string>(type: "TEXT", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemLevelHistoryModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemModel",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Picture = table.Column<string>(type: "TEXT", nullable: true),
                    CVA = table.Column<decimal>(type: "TEXT", nullable: false),
                    Gold = table.Column<decimal>(type: "TEXT", nullable: false),
                    Gem = table.Column<decimal>(type: "TEXT", nullable: false),
                    SellStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Energy = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ItemGroupRefID = table.Column<string>(type: "TEXT", nullable: true),
                    PlayerID = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemRarityModel",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemRarityModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemStatusHistoryModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemID = table.Column<string>(type: "TEXT", nullable: false),
                    ATK = table.Column<int>(type: "INTEGER", nullable: false),
                    HP = table.Column<int>(type: "INTEGER", nullable: false),
                    DEF = table.Column<int>(type: "INTEGER", nullable: false),
                    CRI = table.Column<int>(type: "INTEGER", nullable: false),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false),
                    CRIDMG = table.Column<int>(type: "INTEGER", nullable: false),
                    ASPD = table.Column<int>(type: "INTEGER", nullable: false),
                    EVA = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemStatusHistoryModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ItemStatusModel",
                columns: table => new
                {
                    ItemID = table.Column<string>(type: "TEXT", nullable: false),
                    ATK = table.Column<int>(type: "INTEGER", nullable: false),
                    HP = table.Column<int>(type: "INTEGER", nullable: false),
                    DEF = table.Column<int>(type: "INTEGER", nullable: false),
                    CRI = table.Column<int>(type: "INTEGER", nullable: false),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false),
                    CRIDMG = table.Column<int>(type: "INTEGER", nullable: false),
                    ASPD = table.Column<int>(type: "INTEGER", nullable: false),
                    EVA = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemStatusModel", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypeModel",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypeModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlayerModel",
                columns: table => new
                {
                    PlayerID = table.Column<string>(type: "TEXT", nullable: false),
                    UserID = table.Column<string>(type: "TEXT", nullable: false),
                    CVA = table.Column<decimal>(type: "TEXT", nullable: false),
                    Gold = table.Column<decimal>(type: "TEXT", nullable: false),
                    Gem = table.Column<decimal>(type: "TEXT", nullable: false),
                    TopScore = table.Column<int>(type: "INTEGER", nullable: false),
                    BestTimeMilliseconds = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerModel", x => x.PlayerID);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatusHistoryModel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PlayerID = table.Column<string>(type: "TEXT", nullable: false),
                    ATK = table.Column<int>(type: "INTEGER", nullable: false),
                    HP = table.Column<int>(type: "INTEGER", nullable: false),
                    DEF = table.Column<int>(type: "INTEGER", nullable: false),
                    CRI = table.Column<int>(type: "INTEGER", nullable: false),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false),
                    CRIDMG = table.Column<int>(type: "INTEGER", nullable: false),
                    ASPD = table.Column<int>(type: "INTEGER", nullable: false),
                    EVA = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatusHistoryModel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatusModel",
                columns: table => new
                {
                    PlayerID = table.Column<string>(type: "TEXT", nullable: false),
                    ATK = table.Column<int>(type: "INTEGER", nullable: false),
                    HP = table.Column<int>(type: "INTEGER", nullable: false),
                    DEF = table.Column<int>(type: "INTEGER", nullable: false),
                    CRI = table.Column<int>(type: "INTEGER", nullable: false),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false),
                    CRIDMG = table.Column<int>(type: "INTEGER", nullable: false),
                    ASPD = table.Column<int>(type: "INTEGER", nullable: false),
                    EVA = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatusModel", x => x.PlayerID);
                });

            migrationBuilder.CreateTable(
                name: "TransferTransactionModel",
                columns: table => new
                {
                    ID = table.Column<string>(type: "TEXT", nullable: false),
                    FromPlayerID = table.Column<string>(type: "TEXT", nullable: false),
                    ToPlayerID = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ItemID = table.Column<string>(type: "TEXT", nullable: true),
                    CVAAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    GoldAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    GemAmount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferTransactionModel", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemEnergyHistoryModel");

            migrationBuilder.DropTable(
                name: "ItemGroupModel");

            migrationBuilder.DropTable(
                name: "ItemLevelHistoryModel");

            migrationBuilder.DropTable(
                name: "ItemModel");

            migrationBuilder.DropTable(
                name: "ItemRarityModel");

            migrationBuilder.DropTable(
                name: "ItemStatusHistoryModel");

            migrationBuilder.DropTable(
                name: "ItemStatusModel");

            migrationBuilder.DropTable(
                name: "ItemTypeModel");

            migrationBuilder.DropTable(
                name: "PlayerModel");

            migrationBuilder.DropTable(
                name: "PlayerStatusHistoryModel");

            migrationBuilder.DropTable(
                name: "PlayerStatusModel");

            migrationBuilder.DropTable(
                name: "TransferTransactionModel");
        }
    }
}
