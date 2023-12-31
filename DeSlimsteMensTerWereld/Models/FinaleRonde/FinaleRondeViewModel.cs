using DeSlimsteMensTerWereld.Gameplay;

namespace DeSlimsteMensTerWereld.Models.FinaleRonde;

public class FinaleRondeViewModel
{
    public List<TeamViewModel> Teams { get; set; }
    public List<FinaleRondeDetails> Rondes { get; set; }
    public int ActiveRonde { get; set; } = 1;
}