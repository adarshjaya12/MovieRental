using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace MovieRentals.Models
{
    public class Movies
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MovieName { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }
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
