using System;

namespace HealthCare.Model
{
    public class Bill
    {
        public int BillID { get; set; }
        public int VisitID { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime BillingDate { get; set; }
        public Visit Visit { get; set; }
    }
}
