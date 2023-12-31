using DeSlimsteMensTerWereld.Gameplay;
using DeSlimsteMensTerWereld.Models;
using DeSlimsteMensTerWereld.Models.DrieZesNegenRonde;
using DeSlimsteMensTerWereld.Models.OpenDeur;
using Microsoft.AspNetCore.Mvc;

namespace DeSlimsteMensTerWereld.Controllers;

public class OpenDeurController : Controller
{
    // GET
    public IActionResult Index()
    {
        var teams = TeamTracker.Teams.Select(team => new TeamViewModel
        {
            TeamName = team.Name, 
            AmountOfSecondsLeft = team.AmountOfSecondsLeft
        }).ToList();
        
        var openDeurViewModel = new OpenDeurViewModel();
        openDeurViewModel.Teams = teams;
        openDeurViewModel.Rondes = OpenDeurTracker.Rondes;
        openDeurViewModel.ActiveRonde = OpenDeurTracker.ActiveRonde;
        
        return View(openDeurViewModel);
    }
    
    public IActionResult RondeDetails()
    {
        var teams = TeamTracker.Teams.Select(team => new TeamViewModel
        {
            TeamName = team.Name, 
            AmountOfSecondsLeft = team.AmountOfSecondsLeft
        }).ToList();
        
        var openDeurViewModel = new OpenDeurViewModel();
        openDeurViewModel.Teams = teams;
        openDeurViewModel.Rondes = OpenDeurTracker.Rondes;
        openDeurViewModel.ActiveRonde = OpenDeurTracker.ActiveRonde;

        return Json(openDeurViewModel);
    }
}