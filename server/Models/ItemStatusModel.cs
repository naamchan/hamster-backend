using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class ItemStatusModel
{
    [Key]
    public string ItemID { get; set; } = default!;
    public int ATK { get; set; }
    public int HP { get; set; }
    public int DEF { get; set; }
    public int CRI { get; set; }
    public int Speed { get; set; }
    public int CRIDMG { get; set; }
    public int ASPD { get; set; }
    public int EVA { get; set; }
}