using System;
using System.ComponentModel.DataAnnotations;

 

namespace Domain

{

    public class Product

    {

        public Guid Id { get; set; }
        [Required]
        [RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 5 characters required")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Maximum 30 characters")]
        public string ProductName { get; set; }

        public string ShortDescription { get; set; }

        public string DetailedDescription { get; set; }

        public string Category { get; set; }

        public string StartingPrice{get;set;}

        public DateTime BidEnDate{get;set;}

 

    }

}

 