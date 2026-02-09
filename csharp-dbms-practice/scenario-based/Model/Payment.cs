using System;

namespace HealthCare.Model
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int BillID { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMode { get; set; }
        public Bill Bill { get; set; }
    }
}
