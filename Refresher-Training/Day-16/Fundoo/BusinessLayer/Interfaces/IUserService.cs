using ModelLayer.DTOs;

namespace BusinessLayer.Interfaces
{
    // Defines the contract covering the full user lifecycle: Onboarding, Authentication, and Account Recovery
    public interface IUserService
    {
        // 1. Onboarding: Registers a new user in the system
        Task<ApiResponse> RegisterAsync(RegisterRequest request);

        // 2. Authentication: Verifies credentials and generates an access token
        Task<LoginResponse> LoginAsync(LoginRequest request);

        // 3. Recovery Request: Initiates password reset by sending a token/link
        Task<ApiResponse> ForgotPasswordAsync(ForgotPasswordRequest request);

        // 4. Recovery Completion: Updates the user password after token verification
        Task<ApiResponse> ResetPasswordAsync(ResetPasswordRequest request);
    }
}