using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class ItemGroupModel
{
    [Key]
    public string ID { get; set; } = default!;
    public string Name { get; set; } = default!;
    public int MaxLevel { get; set; }
}