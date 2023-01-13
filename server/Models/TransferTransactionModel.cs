using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class TransferTransactionModel
{
    [Key]
    public string ID { get; set; } = default!;
    public string FromPlayerID { get; set; } = default!;
    public string ToPlayerID { get; set; } = default!;
    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }

    public string? ItemID { get; set; } = default!;
    public decimal CVAAmount { get; set; }
    public decimal GoldAmount { get; set; }
    public decimal GemAmount { get; set; }
}