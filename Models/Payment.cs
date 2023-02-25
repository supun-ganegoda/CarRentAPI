#nullable disable
using System;
using System.Collections.Generic;

namespace CarRentAPI.Models
{
    public partial class Payment
    {
        public string PaymentId { get; set; }
        public string Date { get; set; }
        public int? Amount { get; set; }
        public string Status { get; set; }
        public int? UserNic { get; set; }
        public string VehicalId { get; set; }

        public virtual User UserNicNavigation { get; set; }
    }
}