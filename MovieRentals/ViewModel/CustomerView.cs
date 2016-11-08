using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentals.Models;
namespace MovieRentals.ViewModel
{
    public class CustomerView
    {
        public IEnumerable<MembershipType> MembershipTypes{ get; set; }
        public Customer Customer { get; set; }
        public List<GenderClass> CustomerGender{ get; set; }
    }

    public class GenderClass
    {
        public int GenderId { get; set; }
        public string GenderType { get; set; }
    }
}