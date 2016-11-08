using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace MovieRentals.Models
{
    public class Customer
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [Display(Name="Customer Name")]
        public string CustomerName { get; set; }


        [Required]
        [Display(Name = "Gender")]
        public string CustomerGender { set; get; }

        //[Required]
        //public byte Age { set; get; }


        [Display(Name = "Date Of Birth")]
        public DateTime? BirthDate { set; get; }


        public bool IsSubscribedToNewsLetter { set; get; }

        public byte MembershipTypeId { get; set; }

        
        public MembershipType MembershipType{ get; set; }
    }
}