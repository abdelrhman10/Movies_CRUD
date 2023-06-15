using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies_CRUD.Models
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Auto generate this value
        public byte Id { get; set; }

        [Required,MaxLength(100)]
        public string Name { get; set; }
    }
}
