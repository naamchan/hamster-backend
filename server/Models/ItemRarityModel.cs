using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class ItemRarityModel
{
    [Key]
    public string ID { get; set; } = default!;
    public string Name { get; set; } = default!;
}