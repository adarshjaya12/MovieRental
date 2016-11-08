using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MovieRentals.Models
{
    public class MembershipType
    {
        [Key]
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { set; get; }
        public string MemberName { set; get; }
        public short SignUpFee{ get; set; }
        public byte DurationInMonth { set; get; }
        public byte DiscountRate { get; set; }
    }
}