using Movies_CRUD.Models;
using System.ComponentModel.DataAnnotations;

namespace Movies_CRUD.ViewModels
{
    public class MovieFormViewModel
    {
        [Required,StringLength(250)]
        public string Title { get; set; }
        public int Year { get; set; }
        [Range(1,10)]
        public double Rate { get; set; }

        [Required, StringLength(2500)]
        public string StoryLine { get; set; }

        public byte[] Poster { get; set; }

        [Display(Name ="Genre")]
        public byte GenreId { set; get; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}
