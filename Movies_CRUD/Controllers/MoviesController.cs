using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_CRUD.Models;
using Movies_CRUD.ViewModels;

namespace Movies_CRUD.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public MoviesController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var movies =await _dbContext.Movies.ToListAsync();
            return View(movies);
        }
        public async Task<IActionResult> Create()
        {
            var viewmodel = new MovieFormViewModel
            {
                Genres = await _dbContext.Genres.OrderBy(m => m.Name).ToListAsync()
            };
            return View(viewmodel);
        }
    }
}
