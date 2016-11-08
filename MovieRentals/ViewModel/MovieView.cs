using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentals.Models;
namespace MovieRentals.ViewModel
{
    public class MovieView
    {
        public Movies Movies { get; set; }
        public IList<Genres> Genres { set; get; }
    }
}