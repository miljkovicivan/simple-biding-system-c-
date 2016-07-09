using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iep_projekat_2.Models
{
    public enum AuctionState
    {
        draft, ready, open, sold, expired
    }

    public class Auction
    {
        public int Id { get; set; }
        public string product_name { get; set; }
        public double duration { get; set; }
        public double price { get; set; }
        public DateTime creation_datetime { get; set; }
        public DateTime opening_datetime { get; set; }
        public DateTime closure_datetime { get; set; }
        public bool active { get; set; }
        public AuctionState? state { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }
    }
}