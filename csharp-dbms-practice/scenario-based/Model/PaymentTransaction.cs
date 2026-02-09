using System;

namespace HealthCare.Model
{
    public class PaymentTransaction
    {
        public int TransactionID { get; set; }
        public int BillID { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMode { get; set; }
        public DateTime TransactionDate { get; set; }
        public string PerformedBy { get; set; }
        public Bill Bill { get; set; }
    }
}
