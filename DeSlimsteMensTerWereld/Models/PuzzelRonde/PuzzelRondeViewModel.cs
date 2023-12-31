using DeSlimsteMensTerWereld.Gameplay;

namespace DeSlimsteMensTerWereld.Models.PuzzelRonde;

public class PuzzelRondeViewModel
{
    public List<TeamViewModel> Teams { get; set; }
    public List<PuzzelRondeDetails> Rondes { get; set; }
    public int ActiveRonde { get; set; } = 1;
}

public class PuzzelRondeDetails
{
    public PuzzelRondeGroup Group1 { get; set; }
    public PuzzelRondeGroup Group2 { get; set; }
    public PuzzelRondeGroup Group3 { get; set; }
}

public class PuzzelRondeGroup
{
    public string Antwoord { get; set; }
    public bool IsActive { get; set; }
    public string Trefwoord1 { get; set; }
    public string Trefwoord2 { get; set; }
    public string Trefwoord3 { get; set; }
    public string Trefwoord4 { get; set; }
}