
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain

{

    public class Bid

    {
           public Guid Id { get; set; }

        public double BidAmount { get; set; }
        [Required]
        public string? ProductId { get; set; }
        [Required]
        public string? SellerId { get; set; }
        public string? BuyerId { get; set; }

        public string? category { get; set; }

        public DateTime Date { get; set; }

       

    }

}