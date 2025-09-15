using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MovieAPI.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(40)]
        public required string Name { get; set; }
        [Required]
        [Range(1, 100)]
        public decimal Price { get; set; }
        // Navigation property
        [ValidateNever]
        public Genre? Genre { get; set; }

        // Foreign key
        public int GenreId { get; set; }

        public DateOnly ReleaseDate { get; set; }
    }
}