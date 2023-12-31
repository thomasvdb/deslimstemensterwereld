using DeSlimsteMensTerWereld.Gameplay;
using DeSlimsteMensTerWereld.Models;
using DeSlimsteMensTerWereld.Models.FilmFragment;
using DeSlimsteMensTerWereld.Models.OpenDeur;
using Microsoft.AspNetCore.Mvc;

namespace DeSlimsteMensTerWereld.Controllers;

public class FilmFragmentController : Controller
{
    // GET
    public IActionResult Index()
    {
        var teams = TeamTracker.Teams.Select(team => new TeamViewModel
        {
            TeamName = team.Name, 
            AmountOfSecondsLeft = team.AmountOfSecondsLeft
        }).ToList();
        
        var filmFragmentViewModel = new FilmFragmentViewModel();
        filmFragmentViewModel.Teams = teams;
        filmFragmentViewModel.Rondes = FilmFragmentTracker.Rondes;
        filmFragmentViewModel.ActiveRonde = FilmFragmentTracker.ActiveRonde;
        
        return View(filmFragmentViewModel);
    }
    
    public IActionResult RondeDetails()
    {
        var teams = TeamTracker.Teams.Select(team => new TeamViewModel
        {
            TeamName = team.Name, 
            AmountOfSecondsLeft = team.AmountOfSecondsLeft
        }).ToList();
        
        var filmFragmentViewModel = new FilmFragmentViewModel();
        filmFragmentViewModel.Teams = teams;
        filmFragmentViewModel.Rondes = FilmFragmentTracker.Rondes;
        filmFragmentViewModel.ActiveRonde = FilmFragmentTracker.ActiveRonde;

        return Json(filmFragmentViewModel);
    }
}