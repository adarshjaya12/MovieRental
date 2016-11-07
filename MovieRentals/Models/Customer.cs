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
        [Display(Name="Customer Name")]
        public string CustomerName { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string CustomerGender { set; get; }
        public byte Age { set; get; }
        [Display(Name = "Date Of Birth")]
        public DateTime? BirthDate { set; get; }
        public bool IsSubscribedToNewsLetter { set; get; }
        
        public MembershipType MembershipType{ get; set; }
    }
}