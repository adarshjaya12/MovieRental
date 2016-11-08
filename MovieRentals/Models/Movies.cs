using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieRentals.Models
{
    public class Movies
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name="Movie Name")]
        public string MovieName { get; set; }
        
        [Display(Name="Released Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        public int GenresId { set; get; }

        public Genres Genres { set; get; }
    }

    public class Genres
    {
        public int GenresId { get; set; }
        public string GenreType { get; set; }
    }
}
