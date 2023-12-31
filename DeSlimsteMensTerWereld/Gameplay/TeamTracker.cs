using DeSlimsteMensTerWereld.Models.PuzzelRonde;

namespace DeSlimsteMensTerWereld.Gameplay;

public static class TeamNames
{
    public static string LynnEnDries = "Lynn en Dries";
    public static string ValerieEnSam = "Valerie en Sam";
    public static string AlineEnMario = "Aline en Mario";
}

public static class TeamTracker
{
    public static System.Timers.Timer? _timer;
    
    public static List<Team> Teams { get; } = new();
    public static Team ActiveTeam { get; set; }
    public static void UpdateSeconds(string teamName, int seconds)
    {
        var team = Teams.Find(team => team.Name == teamName);
        if (team != null)
        {
            team.AmountOfSecondsLeft = seconds;
        }
    }

    public static void StartStopTimer(string teamName)
    {
        if (_timer != null)
        {
            _timer.Stop();
            _timer = null;
        }
        else
        {
            _timer = new System.Timers.Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += (sender, args) =>
            {
                var team = Teams.Find(team => team.Name == teamName);
                team!.AmountOfSecondsLeft -= 1;
            };
            _timer.Start();
        }
    }
}

public static class DrieZesNegenTracker
{
    public static int ActiveQuestion { get; set; } = 1;
}

public static class OpenDeurTracker
{
    public static List<OpenDeurRondeDetails> Rondes { get; set; }
    public static int ActiveRonde { get; set; } = 1;
}

public static class PuzzelRondeTracker
{
    public static List<PuzzelRondeDetails> Rondes { get; set; }
    public static int ActiveRonde { get; set; } = 1;
}

public static class FilmFragmentTracker
{
    public static List<FilmFragmentRondeDetails> Rondes { get; set; }
    public static int ActiveRonde { get; set; } = 1;
}

public static class FinaleRondeTracker
{
    public static List<FinaleRondeDetails> Rondes { get; set; }
    public static int ActiveRonde { get; set; } = 1;
}

public class OpenDeurRondeDetails
{
    public string Antwoord1 { get; set; }
    public bool ToonAntwoord1 { get; set; } = false;
    
    public string Antwoord2 { get; set; }
    public bool ToonAntwoord2 { get; set; } = false;
    
    public string Antwoord3 { get; set; }
    public bool ToonAntwoord3 { get; set; } = false;
    
    public string Antwoord4 { get; set; }
    public bool ToonAntwoord4 { get; set; } = false;
}

public class FilmFragmentRondeDetails
{
    public string Antwoord1 { get; set; }
    public bool ToonAntwoord1 { get; set; } = false;
    
    public string Antwoord2 { get; set; }
    public bool ToonAntwoord2 { get; set; } = false;
    
    public string Antwoord3 { get; set; }
    public bool ToonAntwoord3 { get; set; } = false;
    
    public string Antwoord4 { get; set; }
    public bool ToonAntwoord4 { get; set; } = false;
    
    public string Antwoord5 { get; set; }
    public bool ToonAntwoord5 { get; set; } = false;
}

public class FinaleRondeDetails
{
    public string Antwoord1 { get; set; }
    public bool ToonAntwoord1 { get; set; } = false;
    
    public string Antwoord2 { get; set; }
    public bool ToonAntwoord2 { get; set; } = false;
    
    public string Antwoord3 { get; set; }
    public bool ToonAntwoord3 { get; set; } = false;
    
    public string Antwoord4 { get; set; }
    public bool ToonAntwoord4 { get; set; } = false;
    
    public string Antwoord5 { get; set; }
    public bool ToonAntwoord5 { get; set; } = false;
}