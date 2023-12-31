using DeSlimsteMensTerWereld.Gameplay;
using DeSlimsteMensTerWereld.Models;
using DeSlimsteMensTerWereld.Models.MuziekRonde;
using Microsoft.AspNetCore.Mvc;

namespace DeSlimsteMensTerWereld.Controllers;

public class MuziekRondeController : Controller
{
    public IActionResult Index()
    {
        var teams = TeamTracker.Teams.Select(team => new TeamViewModel
        {
            TeamName = team.Name, 
            AmountOfSecondsLeft = team.AmountOfSecondsLeft
        }).ToList();
        
        return View(new MuziekRondeViewModel { Teams = teams });
    }
}