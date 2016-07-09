using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iep_projekat_2.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public DateTime creation_datetime { get; set; }

        public virtual Auction auction { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}