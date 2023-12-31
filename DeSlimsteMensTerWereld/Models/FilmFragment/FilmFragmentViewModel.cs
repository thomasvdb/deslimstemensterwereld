using DeSlimsteMensTerWereld.Gameplay;

namespace DeSlimsteMensTerWereld.Models.FilmFragment;

public class FilmFragmentViewModel
{
    public List<TeamViewModel> Teams { get; set; }
    public List<FilmFragmentRondeDetails> Rondes { get; set; }
    public int ActiveRonde { get; set; } = 1;
}