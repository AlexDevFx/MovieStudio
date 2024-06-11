using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStudio.Contacts.Users;
using MovieStudio.Core;
using MovieStudio.Core.Movies;
using MovieStudio.Models;

namespace MovieStudio.Controllers;

[Authorize(Policy = WebAppConsts.PolicyNames.Director)]
public class MovieDirectorController: Controller
{
    private readonly MoviesProvider _moviesProvider;
    private readonly MoviesManager _moviesManager;
    private readonly IAuthorizedUser _authorizedUser;

    public MovieDirectorController(MoviesProvider moviesProvider,
        MoviesManager moviesManager,
        IAuthorizedUser authorizedUser)
    {
        _authorizedUser = authorizedUser;
        _moviesManager = moviesManager;
        _moviesProvider = moviesProvider;
    }

    public async Task<IActionResult> Movies()
    {
        var result = await _moviesProvider.Director(new Filter(_authorizedUser.DirectorId), HttpContext.RequestAborted);
        
        if(result.result.Success)
            return View(result.data);

        return View();
    }
    
    public IActionResult CreateMovie(CreateMovie model)
    {
        if(!ModelState.IsValid)
            return View();

        var result = _moviesManager.NewMovie(new NewMovie(_authorizedUser.DirectorId.Value,
            model.Title,
            model.Description,
            model.Budget,
            model.SelectedGenres,
            model.Duration,
            model.StartFilming,
            model.EndFilming));

        if (result.Success)
            return View(model);

        return View();
    }

    public IActionResult DeleteMovie(int movieId)
    {
        var result = _moviesManager.DeleteMovie(movieId);

        if (result.Success)
            return View("Success");

        return View("Failed");
    }
}