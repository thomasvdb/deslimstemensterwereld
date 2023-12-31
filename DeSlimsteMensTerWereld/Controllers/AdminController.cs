using DeSlimsteMensTerWereld.Gameplay;
using DeSlimsteMensTerWereld.Models;
using DeSlimsteMensTerWereld.Models.Admin;
using DeSlimsteMensTerWereld.Models.DrieZesNegenRonde;
using DeSlimsteMensTerWereld.Models.FilmFragment;
using DeSlimsteMensTerWereld.Models.FinaleRonde;
using DeSlimsteMensTerWereld.Models.MuziekRonde;
using DeSlimsteMensTerWereld.Models.OpenDeur;
using DeSlimsteMensTerWereld.Models.PuzzelRonde;
using Microsoft.AspNetCore.Mvc;

namespace DeSlimsteMensTerWereld.Controllers;

public class AdminController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var teams = TeamTracker.Teams.Select(team => new TeamViewModel
        {
            TeamName = team.Name, 
            AmountOfSecondsLeft = team.AmountOfSecondsLeft
        }).ToList();

        var openDeurViewModel = new OpenDeurViewModel();
        openDeurViewModel.Rondes = OpenDeurTracker.Rondes;
        openDeurViewModel.ActiveRonde = OpenDeurTracker.ActiveRonde;

        var puzzleRondeViewModel = new PuzzelRondeViewModel();
        puzzleRondeViewModel.Rondes = PuzzelRondeTracker.Rondes;
        puzzleRondeViewModel.ActiveRonde = PuzzelRondeTracker.ActiveRonde;
        
        var filmFragmentViewModel = new FilmFragmentViewModel();
        filmFragmentViewModel.Rondes = FilmFragmentTracker.Rondes;
        filmFragmentViewModel.ActiveRonde = FilmFragmentTracker.ActiveRonde;
        
        var finaleViewModel = new FinaleRondeViewModel();
        finaleViewModel.Rondes = FinaleRondeTracker.Rondes;
        finaleViewModel.ActiveRonde = FinaleRondeTracker.ActiveRonde;

        return View(new AdminViewModel
        {
            Teams = teams, OpenDeurViewModel = openDeurViewModel, PuzzelRondeViewModel = puzzleRondeViewModel,
            FilmFragmentViewModel = filmFragmentViewModel,
            MuziekRondeViewModel = new MuziekRondeViewModel(),
            FinaleRondeViewModel = finaleViewModel
            
        });
    }

    [HttpPut("admin/StartStopTimer/{teamName}")]
    public IActionResult StartStopTimer(string teamName)
    {
        if (teamName == "none")
        {
            return NoContent();
        }
        
        TeamTracker.StartStopTimer(teamName);
        return NoContent();
    }
    
    [HttpGet]
    public IActionResult DrieZesNegenStatus()
    {
        var teams = TeamTracker.Teams.Select(team => new TeamViewModel
        {
            TeamName = team.Name, 
            AmountOfSecondsLeft = team.AmountOfSecondsLeft
        }).ToList();
        
        return Json(new DrieZesNegenRondeViewModel { Teams = teams, ActiveQuestion = DrieZesNegenTracker.ActiveQuestion });
    }
    
    [HttpPut("/Admin/DrieZesNegenStatus/{teamName}")]
    public IActionResult DrieZesNegenStatus(string teamName)
    {
        if (teamName == "none")
        {
            DrieZesNegenTracker.ActiveQuestion++;
            return NoContent();
        }
        
        var team = TeamTracker.Teams.Find(team => team.Name == teamName);
        TeamTracker.ActiveTeam = team!;
        
        if (DrieZesNegenTracker.ActiveQuestion % 3 == 0)
        {
            TeamTracker.ActiveTeam.AmountOfSecondsLeft += 10;
        } 
        
        DrieZesNegenTracker.ActiveQuestion++;
        return NoContent();
    }
    
    [HttpPut("/Admin/AddSecondsToTeam/{teamName}")]
    public IActionResult AddSecondsToTeam(string teamName)
    {
        var team = TeamTracker.Teams.Find(team => team.Name == teamName);
        TeamTracker.ActiveTeam = team!;
        TeamTracker.ActiveTeam.AmountOfSecondsLeft += 11;
 
        return NoContent();
    }
    
    [HttpPut("/Admin/RemoveSecondsFromTeam/{teamName}")]
    public IActionResult RemoveSecondsFromTeam(string teamName)
    {
        var team = TeamTracker.Teams.Find(team => team.Name == teamName);
        TeamTracker.ActiveTeam = team!;
        TeamTracker.ActiveTeam.AmountOfSecondsLeft -= 20;
 
        return NoContent();
    }
    
    [HttpPut("/Admin/DisableTeam/{teamName}")]
    public IActionResult DisableTeam(string teamName)
    {
        var team = TeamTracker.Teams.Find(team => team.Name == teamName);
        team.Active = !team.Active;
 
        return NoContent();
    }
    
    [HttpPut("/Admin/OpenDeur/{teamName}/{rondeNummer}/{vraagNummer}")]
    public IActionResult OpenDeur(string teamName, int rondeNummer, int vraagNummer)
    {
        if (teamName != "none")
        {
            var team = TeamTracker.Teams.Find(team => team.Name == teamName);
            TeamTracker.ActiveTeam = team!;
            TeamTracker.ActiveTeam.AmountOfSecondsLeft += 21;
        }

        var ronde = OpenDeurTracker.Rondes.Skip(rondeNummer - 1).First();
        if (vraagNummer == 1)
        {
            ronde.ToonAntwoord1 = true;
        }
        
        if (vraagNummer == 2)
        {
            ronde.ToonAntwoord2 = true;
        }
        
        if (vraagNummer == 3)
        {
            ronde.ToonAntwoord3 = true;
        }
        
        if (vraagNummer == 4)
        {
            ronde.ToonAntwoord4 = true;
        }

        if (teamName != "none")
        {
            if (ronde is { ToonAntwoord1: true, ToonAntwoord2: true, ToonAntwoord3: true, ToonAntwoord4: true })
            {
                TeamTracker.StartStopTimer(teamName);
            }
        }

        return NoContent();
    }
    
    [HttpPut("/Admin/FilmFragment/{teamName}/{rondeNummer}/{vraagNummer}")]
    public IActionResult FilmFragment(string teamName, int rondeNummer, int vraagNummer)
    {
        var ronde = FilmFragmentTracker.Rondes.Skip(rondeNummer - 1).First();
        var aantalJuisteVragen = 1 + (ronde.ToonAntwoord1 ? 1 : 0) + (ronde.ToonAntwoord2 ? 1 : 0) +
                                 (ronde.ToonAntwoord3 ? 1 : 0) + (ronde.ToonAntwoord4 ? 1 : 0) +
                                 (ronde.ToonAntwoord5 ? 1 : 0);

        if (teamName != "none")
        {
            var team = TeamTracker.Teams.Find(team => team.Name == teamName);
            TeamTracker.ActiveTeam = team!;
            TeamTracker.ActiveTeam.AmountOfSecondsLeft += (aantalJuisteVragen * 10) + 1;
        }

        if (vraagNummer == 1)
        {
            ronde.ToonAntwoord1 = true;
        }
        
        if (vraagNummer == 2)
        {
            ronde.ToonAntwoord2 = true;
        }
        
        if (vraagNummer == 3)
        {
            ronde.ToonAntwoord3 = true;
        }
        
        if (vraagNummer == 4)
        {
            ronde.ToonAntwoord4 = true;
        }
        
        if (vraagNummer == 5)
        {
            ronde.ToonAntwoord5 = true;
        }

        if (teamName != "none")
        {
            if (ronde is
                {
                    ToonAntwoord1: true, ToonAntwoord2: true, ToonAntwoord3: true, ToonAntwoord4: true,
                    ToonAntwoord5: true
                })
            {
                TeamTracker.StartStopTimer(teamName);
            }
        }

        return NoContent();
    }
    
    [HttpPut("/Admin/FinaleRonde/{teamName}/{rondeNummer}/{vraagNummer}")]
    public IActionResult FinaleRonde(string teamName, int rondeNummer, int vraagNummer)
    {
        var ronde = FinaleRondeTracker.Rondes.Skip(rondeNummer - 1).First();

        if (teamName != "none")
        {
            var team = TeamTracker.Teams.Find(team => team.Name != teamName && team.Active);
            team!.AmountOfSecondsLeft -= 20;

            if (team.AmountOfSecondsLeft < 0)
            {
                team.AmountOfSecondsLeft = 0;
            }
        }

        if (vraagNummer == 1)
        {
            ronde.ToonAntwoord1 = true;
        }
        
        if (vraagNummer == 2)
        {
            ronde.ToonAntwoord2 = true;
        }
        
        if (vraagNummer == 3)
        {
            ronde.ToonAntwoord3 = true;
        }
        
        if (vraagNummer == 4)
        {
            ronde.ToonAntwoord4 = true;
        }
        
        if (vraagNummer == 5)
        {
            ronde.ToonAntwoord5 = true;
        }

        if (teamName != "none")
        {
            if (ronde is
                {
                    ToonAntwoord1: true, ToonAntwoord2: true, ToonAntwoord3: true, ToonAntwoord4: true,
                    ToonAntwoord5: true
                })
            {
                TeamTracker.StartStopTimer(teamName);
            }
        }

        return NoContent();
    }
    
    [HttpPut("/Admin/PuzzelRonde/{teamName}/{rondeNummer}/{groepNummer}")]
    public IActionResult PuzzleRonde(string teamName, int rondeNummer, int groepNummer)
    {
        if (teamName != "none")
        {
            var team = TeamTracker.Teams.Find(team => team.Name == teamName);
            TeamTracker.ActiveTeam = team!;
            TeamTracker.ActiveTeam.AmountOfSecondsLeft += 31;
        }

        var ronde = PuzzelRondeTracker.Rondes.Skip(rondeNummer - 1).First();
        if (groepNummer == 1)
        {
            ronde.Group1.IsActive = true;
        }
        
        if (groepNummer == 2)
        {
            ronde.Group2.IsActive = true;
        }
        
        if (groepNummer == 3)
        {
            ronde.Group3.IsActive = true;
        }

        if (teamName != "none")
        {
            if (ronde.Group1.IsActive && ronde.Group2.IsActive && ronde.Group3.IsActive)
            {
                TeamTracker.StartStopTimer(teamName);
            }
        }

        return NoContent();
    }
    
    [HttpPut("/Admin/OpenDeur/SetRondeActive/{rondeNummer}")]
    public IActionResult SetRondeActive(int rondeNummer)
    {
        OpenDeurTracker.ActiveRonde = rondeNummer;
        return NoContent();
    }
    
    [HttpPut("/Admin/PuzzleRonde/SetRondeActive/{rondeNummer}")]
    public IActionResult SetPuzzleRondeActive(int rondeNummer)
    {
        PuzzelRondeTracker.ActiveRonde = rondeNummer;
        return NoContent();
    }
    
    [HttpPut("/Admin/FilmFragment/SetRondeActive/{rondeNummer}")]
    public IActionResult SetFilmFragmentActive(int rondeNummer)
    {
        FilmFragmentTracker.ActiveRonde = rondeNummer;
        return NoContent();
    }
    
    [HttpPut("/Admin/Finale/SetRondeActive/{rondeNummer}")]
    public IActionResult SetFinaleActive(int rondeNummer)
    {
        FinaleRondeTracker.ActiveRonde = rondeNummer;
        return NoContent();
    }
}