using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

public class ItemStatusHistoryModel
{
    [Key]
    public int ID { get; set; }

    public string ItemID { get; set; } = default!;
    public int ATK { get; set; }
    public int HP { get; set; }
    public int DEF { get; set; }
    public int CRI { get; set; }
    public int Speed { get; set; }
    public int CRIDMG { get; set; }
    public int ASPD { get; set; }
    public int EVA { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime CreatedAt { get; set; }
}