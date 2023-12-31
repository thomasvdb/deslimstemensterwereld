using DeSlimsteMensTerWereld.Models.FilmFragment;
using DeSlimsteMensTerWereld.Models.FinaleRonde;
using DeSlimsteMensTerWereld.Models.MuziekRonde;
using DeSlimsteMensTerWereld.Models.OpenDeur;
using DeSlimsteMensTerWereld.Models.PuzzelRonde;

namespace DeSlimsteMensTerWereld.Models.Admin;

public class AdminViewModel
{
    public List<TeamViewModel> Teams { get; set; }
    public OpenDeurViewModel OpenDeurViewModel { get; set; }
    public PuzzelRondeViewModel PuzzelRondeViewModel { get; set; }
    public FilmFragmentViewModel FilmFragmentViewModel { get; set; }
    public MuziekRondeViewModel MuziekRondeViewModel { get; set; }
    public FinaleRondeViewModel FinaleRondeViewModel { get; set; }
}