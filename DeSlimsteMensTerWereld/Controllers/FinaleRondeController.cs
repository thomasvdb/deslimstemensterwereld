using DeSlimsteMensTerWereld.Gameplay;
using DeSlimsteMensTerWereld.Models;
using DeSlimsteMensTerWereld.Models.FinaleRonde;
using Microsoft.AspNetCore.Mvc;

namespace DeSlimsteMensTerWereld.Controllers;

public class FinaleRondeController : Controller
{
    public IActionResult Index()
    {
        var teams = TeamTracker.Teams.Where(team => team.Active).Select(team => new TeamViewModel
        {
            TeamName = team.Name, 
            AmountOfSecondsLeft = team.AmountOfSecondsLeft
        }).ToList();
        
        var finaleRondeViewModel = new FinaleRondeViewModel();
        finaleRondeViewModel.Teams = teams;
        finaleRondeViewModel.Rondes = FinaleRondeTracker.Rondes;
        finaleRondeViewModel.ActiveRonde = FinaleRondeTracker.ActiveRonde;
        
        return View(finaleRondeViewModel);
    }
    
    public IActionResult RondeDetails()
    {
        var teams = TeamTracker.Teams.Select(team => new TeamViewModel
        {
            TeamName = team.Name, 
            AmountOfSecondsLeft = team.AmountOfSecondsLeft
        }).ToList();
        
        var finaleRondeViewModel = new FinaleRondeViewModel();
        finaleRondeViewModel.Teams = teams;
        finaleRondeViewModel.Rondes = FinaleRondeTracker.Rondes;
        finaleRondeViewModel.ActiveRonde = FinaleRondeTracker.ActiveRonde;

        return Json(finaleRondeViewModel);
    }
}