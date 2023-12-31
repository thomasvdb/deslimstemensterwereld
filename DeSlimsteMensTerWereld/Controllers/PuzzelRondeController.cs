using DeSlimsteMensTerWereld.Gameplay;
using DeSlimsteMensTerWereld.Models;
using DeSlimsteMensTerWereld.Models.DrieZesNegenRonde;
using DeSlimsteMensTerWereld.Models.OpenDeur;
using DeSlimsteMensTerWereld.Models.PuzzelRonde;
using Microsoft.AspNetCore.Mvc;

namespace DeSlimsteMensTerWereld.Controllers;

public class PuzzelRondeController : Controller
{
    // GET
    public IActionResult Index()
    {
        var teams = TeamTracker.Teams.Select(team => new TeamViewModel
        {
            TeamName = team.Name, 
            AmountOfSecondsLeft = team.AmountOfSecondsLeft
        }).ToList();
        
        var puzzelRondeViewModel = new PuzzelRondeViewModel();
        puzzelRondeViewModel.Teams = teams;
        puzzelRondeViewModel.Rondes = PuzzelRondeTracker.Rondes;
        puzzelRondeViewModel.ActiveRonde = PuzzelRondeTracker.ActiveRonde;
        
        return View(puzzelRondeViewModel);
    }
    
    public IActionResult RondeDetails()
    {
        var teams = TeamTracker.Teams.Select(team => new TeamViewModel
        {
            TeamName = team.Name, 
            AmountOfSecondsLeft = team.AmountOfSecondsLeft
        }).ToList();
        
        var puzzelRondeViewModel = new PuzzelRondeViewModel();
        puzzelRondeViewModel.Teams = teams;
        puzzelRondeViewModel.Rondes = PuzzelRondeTracker.Rondes;
        puzzelRondeViewModel.ActiveRonde = PuzzelRondeTracker.ActiveRonde;

        return Json(puzzelRondeViewModel);
    }
}