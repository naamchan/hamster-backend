using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

public class ItemLevelHistoryModel
{
    [Key]
    public int ID { get; set; }
    public string ItemID { get; set; } = default!;
    public int Level { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }
}