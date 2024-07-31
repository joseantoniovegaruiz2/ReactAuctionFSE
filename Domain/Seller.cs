using System;
using System.ComponentModel.DataAnnotations;

namespace Domain

{

    public class Seller

    {

           public Guid Id { get; set; }
            [Required]
            [RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 5 characters required")]
            [StringLength(30, MinimumLength = 5, ErrorMessage = "Maximum 30 characters")]
            public string FirstName { get; set; }
            [Required]
            [RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 5 characters required")]
            [StringLength(25, MinimumLength = 5, ErrorMessage = "Maximum 25 characters")]
           public string LastName { get; set; }

           public string Address { get; set; }

            public string City { get; set; }

           public string State { get; set; }

           public string Pin { get; set; }
            [Required]
            [RegularExpression(@"^[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]", ErrorMessage = "Minimum 5 characters required")]
           public string Phone { get; set; }
            [Required]
            [DataType(DataType.EmailAddress)]
           public string Email { get; set; }

       

 

    }

}