namespace BusinessLayer.Interfaces
{
    // Contract defining asynchronous email dispatching operations for user notifications (containing resettoken) and security flows
    public interface IEmailService
    {
        // Dispatches a password reset link/token to the specified recipient email asynchronously
        Task SendPasswordResetEmailAsync(string toEmail, string resetToken);
    }
}