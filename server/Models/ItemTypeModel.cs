using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class ItemTypeModel
{
    [Key]
    public string ID { get; set; } = default!;
    public string Name { get; set; } = default!;
}