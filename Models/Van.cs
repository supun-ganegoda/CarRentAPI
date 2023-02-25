#nullable disable
using System;
using System.Collections.Generic;

namespace CarRentAPI.Models
{
    public partial class Van
    {
        public string PlateNo { get; set; }
        public string Name { get; set; }
        public int? Passengers { get; set; }
        public int? Seats { get; set; }
        public int? Doors { get; set; }
        public string Airbags { get; set; }
        public string Url { get; set; }
        public string Drive { get; set; }
        public string Transmission { get; set; }
        public string Ac { get; set; }
        public int? Deposite { get; set; }
        public int? Price { get; set; }
    }
}