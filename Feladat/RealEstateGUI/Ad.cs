using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RealEstate
{

    public class Ad
    {
        public int? id { get; set; }
        public int? rooms { get; set; }
        public string? latLong { get; set; }
        public int? floors { get; set; }
        public int? area { get; set; }
        public string? description { get; set; }
        public bool? freeOfCharge { get; set; }
        public string? imageUrl { get; set; }
        public Seller? seller { get; set; }
        public Category? category { get; set; }
        public DateTime? createAt { get; set; }


    }

}
