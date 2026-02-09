namespace Interface
{
    public interface IBillingService
    {
        // Generate bill for visit
        void GenerateBill();

        // Make payment
        void MakePayment();

        // View bill details
        void ViewBill();

        // View payment history
        void ViewPayments();
    }
}
