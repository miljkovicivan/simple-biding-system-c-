using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace iep_projekat_2.Models
{
    public enum OrderState
    {
        processing, accepted, denied
    }

    public class Order
    {
        public int Id { get; set; }
        public int tokens { get; set; }
        public double price { get; set; }
        public OrderState? status { get; set; }
        public DateTime creation_datetime { get; set; }
        
        public virtual ApplicationUser user { get; set; }
    }
}