using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MovieRentals.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerGender { set; get; }
        public byte Age { set; get; }
        public bool IsSubscribedToNewsLetter { set; get; }
        public MembershipType MembershipType{ get; set; }
        public byte MembershipTypeId { set; get; }


    }
}