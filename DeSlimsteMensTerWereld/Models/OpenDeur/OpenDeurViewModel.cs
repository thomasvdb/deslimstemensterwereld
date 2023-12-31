using DeSlimsteMensTerWereld.Gameplay;

namespace DeSlimsteMensTerWereld.Models.OpenDeur;

public class OpenDeurViewModel
{
    public List<TeamViewModel> Teams { get; set; }
    public List<OpenDeurRondeDetails> Rondes { get; set; }
    public int ActiveRonde { get; set; } = 1;
}