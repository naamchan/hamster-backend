using Microsoft.EntityFrameworkCore;
using server.Models;

public class HamsterDBContext : DbContext
{
    public HamsterDBContext(DbContextOptions<HamsterDBContext> options)
        : base(options)
    {
    }

    public DbSet<server.Models.PlayerModel> PlayerModel { get; set; } = default!;

    public DbSet<server.Models.ItemEnergyHistoryModel> ItemEnergyHistoryModel { get; set; } = default!;

    public DbSet<server.Models.ItemGroupModel> ItemGroupModel { get; set; } = default!;

    public DbSet<server.Models.ItemLevelHistoryModel> ItemLevelHistoryModel { get; set; } = default!;

    public DbSet<server.Models.ItemModel> ItemModel { get; set; } = default!;

    public DbSet<server.Models.ItemRarityModel> ItemRarityModel { get; set; } = default!;

    public DbSet<server.Models.ItemStatusHistoryModel> ItemStatusHistoryModel { get; set; } = default!;

    public DbSet<server.Models.ItemStatusModel> ItemStatusModel { get; set; } = default!;

    public DbSet<server.Models.ItemTypeModel> ItemTypeModel { get; set; } = default!;

    public DbSet<server.Models.PlayerStatusModel> PlayerStatusModel { get; set; } = default!;

    public DbSet<server.Models.PlayerStatusHistoryModel> PlayerStatusHistoryModel { get; set; } = default!;

    public DbSet<server.Models.TransferTransactionModel> TransferTransactionModel { get; set; } = default!;
}
