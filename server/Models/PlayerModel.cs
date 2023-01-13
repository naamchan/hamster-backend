using System.ComponentModel.DataAnnotations;

namespace server.Models;

public class PlayerModel
{
    [Key]
    public string PlayerID { get; set; } = default!;
    public string UserID { get; set; } = default!;
    public decimal CVA { get; set; }
    public decimal Gold { get; set; }
    public decimal Gem { get; set; }
    public int TopScore { get; set; }
    public int BestTimeMilliseconds { get; set; }
}