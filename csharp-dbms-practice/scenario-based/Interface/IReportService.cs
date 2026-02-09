namespace Interface
{
    public interface IReportService
    {
        // Total hospital revenue
        void ShowTotalRevenue();

        // Doctor wise revenue
        void ShowDoctorRevenue();

        // Pending bills
        void ShowPendingBills();

        // Appointment summary
        void ShowDailyAppointments();

        // View audit logs
        void ShowAuditLogs();
    }
}
