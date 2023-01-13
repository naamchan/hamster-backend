using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class ItemModel
{
    [Key]
    public string ID { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Picture { get; set; }
    public decimal CVA { get; set; }
    public decimal Gold { get; set; }
    public decimal Gem { get; set; }
    public SellStatus SellStatus { get; set; }
    public int Level { get; set; }
    public int Energy { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime UpdatedAt { get; set; }

    // Foreign key
    public string? ItemGroupRefID { get; set; } = default!;
    public string? PlayerID { get; set; } = default!;
}

public enum SellStatus
{
    NotSold = 0,
    Sold = 1
}