using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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
            var movies = await _dbContext.Movies.ToListAsync();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieFormViewModel model)
        {
            
            var files = Request.Form.Files;
            var poster = files.FirstOrDefault();
            if (!ModelState.IsValid) 
            {
                model.Genres = await _dbContext.Genres.OrderBy(m => m.Name).ToListAsync();
                //return View(model);
            }




            
            if (!files.Any())
            {
                model.Genres = await _dbContext.Genres.OrderBy(m => m.Name).ToListAsync();
                ModelState.AddModelError("Poster", "Please choose a poster!");
                
                return View(model);
            }

            using var datastream = new MemoryStream();
            await poster.CopyToAsync(datastream);
            var movies = new Movie
            {
                Title = model.Title,
                GenreId=model.GenreId,
                Year= model.Year,
                Rate=model.Rate,
                StoryLine=model.StoryLine,
                Poster=datastream.ToArray(),
            };
            _dbContext.Movies.Add(movies);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
