using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

public class ItemEnergyHistoryModel
{
    [Key]
    public int ID { get; set; }
    public string ItemID { get; set; } = default!;
    public int Energy { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }
}